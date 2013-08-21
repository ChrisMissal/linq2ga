using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Analytics.v3;
using GoogleAnalyticsLinqProvider.Sample.Managers;
using GoogleAnalyticsLinqProvider.Sample.Models;

namespace GoogleAnalyticsLinqProvider.Sample.Controllers
{
    using Ga = GoogleAnalyticsLinqProvider.Core;

    public class IndexController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            try
            {
                analyticsService = GoogleAnalyticsServiceManager.GetAnalyticsService();
            }
            catch
            {
                filterContext.Result = RedirectToAction("SignIn", "GoogleAnalytics");
            }
        }

        /// <summary>
        /// Analytics service object.
        /// </summary>
        AnalyticsService analyticsService;

        /// <summary>
        /// Sample of web action with retrieving the Google Analytics data
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Index()
        {
            VisitorsDataViewModel viewModel = new VisitorsDataViewModel();

            Ga.DataContext context = new Ga.DataContext(Settings.ProfileId, analyticsService);
            var ctx = context.Create(DateTime.Now.AddDays(-7), DateTime.Now);
            viewModel.VisitorsByCountries = 
                ctx.Select(x => new VisitorsByCountryModel() { Country = x.Country, Visitors = x.Visitors })
                .OrderByDesc(x => x.Visitors)
                .OrderBy(x => x.Country)
                .ToList(take: 5);

            viewModel.TotalVisitors = ctx.Select(x => x.Visitors).First();

            return View(viewModel);
        }

    }
}
