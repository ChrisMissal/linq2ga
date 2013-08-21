using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Google.Apis.Analytics.v3;
using Google.Apis.Authentication.OAuth2;
using DotNetOpenAuth.OAuth2;
using System.Text;

namespace GoogleAnalyticsLinqProvider.Sample.Managers
{
    public static class GoogleAnalyticsServiceManager
    {
        /// <summary>
        /// Return Analytics Service object
        /// </summary>
        /// <returns>Analytics Service object</returns>
        public static AnalyticsService GetAnalyticsService()
        {
            var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description);
            provider.ClientIdentifier = Settings.ClientIdentifier;
            provider.ClientSecret = Settings.ClientSecret;

            if (string.IsNullOrWhiteSpace(provider.ClientIdentifier))
            {
                throw new Exception("Client identifier not found");
            }
            if (string.IsNullOrWhiteSpace(provider.ClientSecret))
            {
                throw new Exception("Client secret not found");
            }
            string refreshToken = Settings.RefreshToken;
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                throw new Exception("Refresh token not found");
            }

            var request = HttpContext.Current.Request;
            var authenticator = new OAuth2Authenticator<NativeApplicationClient>(provider, (arg) =>
            {
                IAuthorizationState state = new AuthorizationState(new[] { "https://www.googleapis.com/auth/analytics.readonly" });
                state.Callback = new Uri(string.Format("{0}://{1}{2}/GoogleAnalytics/Callback", request.Url.Scheme, request.Url.Host, request.Url.Port == 80 ? string.Empty : ":" + request.Url.Port));
                state.RefreshToken = refreshToken;
                var result = arg.RefreshToken(state);
                return state;
            });

            return new AnalyticsService(authenticator);
        }

        /// <summary>
        /// Returng Google Analytics Refresh token
        /// </summary>
        /// <param name="code">The code obtained in callback action</param>
        public static void SaveRefreshToken(string code)
        {
            var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description);
            provider.ClientIdentifier = Settings.ClientIdentifier;
            provider.ClientSecret = Settings.ClientSecret;
            var request = HttpContext.Current.Request;
            var authenticator = new OAuth2Authenticator<NativeApplicationClient>(provider, (arg) =>
            {
                IAuthorizationState state = new AuthorizationState(new[] { "https://www.googleapis.com/auth/analytics.readonly" });
                state.Callback = new Uri(string.Format("{0}://{1}{2}/GoogleAnalytics/Callback", request.Url.Scheme, request.Url.Host, request.Url.Port == 80 ? string.Empty : ":" + request.Url.Port));
                var result = arg.ProcessUserAuthorization(code, state);
                if (result.RefreshToken == null)
                {
                    throw new Exception("Can't get refresh token. Invalid credentials.");
                }
                Settings.RefreshToken = result.RefreshToken;
                return result;
            });
            authenticator.LoadAccessToken();
        }

        /// <summary>
        /// Return Google Analytics request url
        /// </summary>
        /// <returns>Google Analytics request url</returns>
        public static string GetRequestUrl()
        {
            var request = HttpContext.Current.Request;
            StringBuilder url = new StringBuilder();
            string clientId = Settings.ClientIdentifier;
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new Exception("Client ID is missing");
            }
            url.Append("https://accounts.google.com/o/oauth2/auth?response_type=code&access_type=offline&");
            url.AppendFormat("client_id={0}&", clientId);
            url.AppendFormat("scope=https://www.googleapis.com/auth/analytics.readonly&");
            url.AppendFormat("redirect_uri={0}://{1}{2}/GoogleAnalytics/Callback", request.Url.Scheme, request.Url.Host, request.Url.Port == 80 ? string.Empty : ":" + request.Url.Port);
            return url.ToString();
        }
    }
}