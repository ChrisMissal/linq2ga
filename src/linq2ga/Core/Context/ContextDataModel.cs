using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linq2ga.Attributes;
using linq2ga.Enums;
using linq2ga.Core.DataFields;

namespace linq2ga.Core
{
    /// <summary>
    /// Google Analytics data model. Contains all available Google Analytics fields.
    /// </summary>
    public class ContextDataModel
    {
        #region Visitor
        /// <summary>
        /// A boolean indicating if a visitor is new or returning.
        /// </summary>
        [FieldDataName("visitorType")]
        public VisitorTypeDimension VisitorType { get; set; }

        /// <summary>
        /// The visit index for a visitor to your property. Each visit from a unique visitor will get its own incremental index starting from 1 for the first visit. Subsequent visits do not change previous visit indicies. For example, if a certain visitor has 4 visits to your website, ga:visitCount for that visitor will have 4 distinct values of '1' through '4'.
        /// </summary>
        [FieldDataName("visitCount")]
        public Dimension<int> VisitCount { get; set; }

        /// <summary>
        /// The number of days elapsed since visitors last visited your property. Used to calculate visitor loyalty.
        /// </summary>
        [FieldDataName("daysSinceLastVisit")]
        public Dimension<int> DaysSinceLastVisit { get; set; }

        /// <summary>
        /// The value provided when you define custom visitor segments for your property.
        /// </summary>
        [FieldDataName("userDefinedValue")]
        public Dimension<string> UserDefinedValue { get; set; }

        /// <summary>
        /// Total number of visitors to your property for the requested time period.
        /// </summary>
        [FieldDataName("visitors")]
        public Metric<int> Visitors { get; set; }

        /// <summary>
        /// The number of visitors whose visit to your property was marked as a first-time visit.
        /// </summary>
        [FieldDataName("newVisits")]
        public Metric<int> NewVisits { get; set; }

        /// <summary>
        /// The percentage of visits by people who had never visited your property before.
        /// </summary>
        [FieldDataName("percentNewVisits")]
        public Metric<double> PercentNewVisits { get; set; }
        #endregion

        #region Session
        /// <summary>
        /// The length of a visit to your property measured in seconds and reported in second increments. The value returned is a string.
        /// </summary>
        [FieldDataName("visitLength")]
        public Dimension<string> VisitLength { get; set; }

        /// <summary>
        /// Counts the total number of sessions.
        /// </summary>
        [FieldDataName("visits")]
        public Metric<int> Visits { get; set; }

        /// <summary>
        /// The total number of single page (or single engagement hit) sessions for your property.
        /// </summary>
        [FieldDataName("bounces")]
        public Metric<int> Bounces { get; set; }

        /// <summary>
        /// The total duration of visitor sessions
        /// </summary>
        [FieldDataName("timeOnSite")]
        public SecondsTimeSpanMetric TimeOnSite { get; set; }

        /// <summary>
        /// The percentage of single-page visits (i.e. visits in which the person left your property from the entrance page).
        /// </summary>
        [FieldDataName("entranceBounceRate")]
        public Metric<double> EntranceBounceRate { get; set; }

        /// <summary>
        /// The percentage of single-page visits (i.e., visits in which the person left your property from the first page).
        /// </summary>
        [FieldDataName("visitBounceRate")]
        public Metric<double> VisitBounceRate { get; set; }

        /// <summary>
        /// The average duration visitor sessions
        /// </summary>
        [FieldDataName("avgTimeOnSite")]
        public SecondsTimeSpanMetric AvgTimeOnSite { get; set; }
        #endregion

        #region Traffic Sources
        /// <summary>
        /// The path of the referring URL (e.g. document.referrer). If someone places a link to your property on their website, this element contains the path of the page that contains the referring link.
        /// </summary>
        [FieldDataName("referralPath")]
        public Dimension<string> ReferralPath { get; set; }

        /// <summary>
        /// When using manual campaign tracking, the value of the utm_campaign campaign tracking parameter. When using AdWords autotagging, the name(s) of the online ad campaign that you use for your property. Otherwise the value (not set) is used.
        /// </summary>
        [FieldDataName("campaign")]
        public Dimension<string> Campaign { get; set; }

        /// <summary>
        /// The source of referrals to your property. When using manual campaign tracking, the value of the utm_source campaign tracking parameter. When using AdWords autotagging, the value is google. Otherwise the domain of the source referring the visitor to your property (e.g. document.referrer). The value may also contain a port address. If the visitor arrived without a referrer, the value is (direct)
        /// </summary>
        [FieldDataName("source")]
        public Dimension<string> Source { get; set; }

        /// <summary>
        /// The type of referrals to your property. When using manual campaign tracking, the value of the utm_medium campaign tracking parameter. When using AdWords autotagging, the value is ppc. If the user comes from a search engine detected by Google Analytics, the value is organic. If the referrer is not a search engine, the value is referral. If the visitor came directly to the property, and document.referrer is empty, the value is (none).
        /// </summary>
        [FieldDataName("medium")]
        public MediumTypeDimension Medium { get; set; }

        /// <summary>
        /// When using manual campaign tracking, the value of the utm_term campaign tracking parameter. When using AdWords autotagging or if a visitor used organic search to reach your property, the keywords used by visitors to reach your property. Otherwise the value is (not set).
        /// </summary>
        [FieldDataName("keyword")]
        public Dimension<string> Keyword { get; set; }

        /// <summary>
        /// When using manual campaign tracking, the value of the utm_content campaign tracking parameter. When using AdWords autotagging, the first line of the text for your online Ad campaign. If you are using mad libs for your AdWords content, this field displays the keywords you provided for the mad libs keyword match. Otherwise the value is (not set)
        /// </summary>
        [FieldDataName("adContent")]
        public Dimension<string> AdContent { get; set; }

        /// <summary>
        /// Name of the social network. This can be related to the referring social network for traffic sources, or to the social network for social data hub activities. E.g. Google+, Blogger, reddit, etc.
        /// </summary>
        [FieldDataName("socialNetwork")]
        public Dimension<string> SocialNetwork { get; set; }

        /// <summary>
        /// Indicates visits that arrived to the property from a social source (i.e. A social network such as Google+, Facebook, Twitter, etc.). The possible values are Yes or No where the first letter is capitalized.
        /// </summary>
        [FieldDataName("hasSocialSourceReferral")]
        public YesNoBoolDimension HasSocialSourceReferral { get; set; }

        /// <summary>
        /// The number of organic searches that happened within a session. This metric is search engine agnostic.
        /// </summary>
        [FieldDataName("organicSearches")]
        public Metric<int> OrganicSearches { get; set; }
        #endregion

        #region AdWords
        /// <summary>
        /// The name of your AdWords ad group.
        /// </summary>
        [FieldDataName("adGroup")]
        public Dimension<string> AdGroup { get; set; }

        /// <summary>
        /// The location of the advertisement on the hosting page (Top, RHS, or not set).
        /// </summary>
        [FieldDataName("adSlot")]
        public AdSlotTypeDimension AdSlot { get; set; }

        /// <summary>
        /// The ad slot positions in which your AdWords ads appeared (1-8).
        /// </summary>
        [FieldDataName("adSlotPosition")]
        public MediumTypeDimension AdSlotPosition { get; set; }

        /// <summary>
        /// The networks used to deliver your ads (Content, Search, Search partners, etc.).
        /// </summary>
        [FieldDataName("adDistributionNetwork")]
        public Dimension<string> AdDistributionNetwork { get; set; }

        /// <summary>
        /// The match types applied to your keywords (Phrase, Exact, Broad, etc.). Ads on the content network are identified as "Content network".
        /// </summary>
        [FieldDataName("adMatchType")]
        public Dimension<string> AdMatchType { get; set; }

        /// <summary>
        /// The search queries that triggered impressions of your AdWords ads.
        /// </summary>
        [FieldDataName("adMatchedQuery")]
        public Dimension<string> AdMatchedQuery { get; set; }

        /// <summary>
        /// The domains where your ads on the content network were placed.
        /// </summary>
        [FieldDataName("adPlacementDomain")]
        public Dimension<string> AdPlacementDomain { get; set; }

        /// <summary>
        /// The URLs where your ads on the content network were placed.
        /// </summary>
        [FieldDataName("adPlacementUrl")]
        public Dimension<string> AdPlacementUrl { get; set; }

        /// <summary>
        /// Your AdWords ad formats (Text, Image, Flash, Video, etc.).
        /// </summary>
        [FieldDataName("adFormat")]
        public Dimension<string> AdFormat { get; set; }

        /// <summary>
        /// How your AdWords ads were targeted (keyword, placement, and vertical targeting, etc.).
        /// </summary>
        [FieldDataName("adTargetingType")]
        public Dimension<string> AdTargetingType { get; set; }

        /// <summary>
        /// How you manage your ads on the content network. Values are Automatic placements or Managed placements.
        /// </summary>
        [FieldDataName("adTargetingOption")]
        public AdTargetingOptionTypeDimension AdTargetingOption { get; set; }

        /// <summary>
        /// The URLs your AdWords ads displayed.
        /// </summary>
        [FieldDataName("adDisplayUrl")]
        public Dimension<string> AdDisplayUrl { get; set; }

        /// <summary>
        /// The URLs to which your AdWords ads referred traffic.
        /// </summary>
        [FieldDataName("adDestinationUrl")]
        public Dimension<string> AdDestinationUrl { get; set; }

        /// <summary>
        /// A string. Corresponds to AdWords API AccountInfo.customerId.
        /// </summary>
        [FieldDataName("adwordsCustomerID")]
        public Dimension<string> AdwordsCustomerID { get; set; }

        /// <summary>
        /// A string. Corresponds to AdWords API Campaign.id.
        /// </summary>
        [FieldDataName("adwordsCampaignID")]
        public Dimension<string> AdwordsCampaignID { get; set; }

        /// <summary>
        /// A string. Corresponds to AdWords API AdGroup.id.
        /// </summary>
        [FieldDataName("adwordsAdGroupID")]
        public Dimension<string> AdwordsAdGroupID { get; set; }

        /// <summary>
        /// A string. Corresponds to AdWords API Ad.id.
        /// </summary>
        [FieldDataName("adwordsCreativeID")]
        public Dimension<string> AdwordsCreativeID { get; set; }

        /// <summary>
        /// A string. Corresponds to AdWords API Criterion.id.
        /// </summary>
        [FieldDataName("AdwordsCriteriaID")]
        public Dimension<string> AdwordsCriteriaID { get; set; }

        /// <summary>
        /// Total number of campaign impressions.
        /// </summary>
        [FieldDataName("impressions")]
        public Metric<int> Impressions { get; set; }

        /// <summary>
        /// The total number of times users have clicked on an ad to reach your property.
        /// </summary>
        [FieldDataName("adClicks")]
        public Metric<int> AdClicks { get; set; }

        /// <summary>
        /// Derived cost for the advertising campaign. The currency for this value is based on the currency that you set in your AdWords account.
        /// </summary>
        [FieldDataName("adCost")]
        public Metric<double> AdCost { get; set; }

        /// <summary>
        /// Cost per thousand impressions.
        /// </summary>
        [FieldDataName("CPM")]
        public Metric<double> CPM { get; set; }

        /// <summary>
        /// Cost to advertiser per click.
        /// </summary>
        [FieldDataName("CPC")]
        public Metric<double> CPC { get; set; }

        /// <summary>
        /// Click-through-rate for your ad. This is equal to the number of clicks divided by the number of impressions for your ad (e.g. how many times users clicked on one of your ads where that ad appeared).
        /// </summary>
        [FieldDataName("CTR")]
        public Metric<double> CTR { get; set; }

        /// <summary>
        /// The cost per transaction for your property.
        /// </summary>
        [FieldDataName("costPerTransaction")]
        public Metric<double> CostPerTransaction { get; set; }

        /// <summary>
        /// The cost per goal conversion for your property.
        /// </summary>
        [FieldDataName("costPerGoalConversion")]
        public Metric<double> CostPerGoalConversion { get; set; }

        /// <summary>
        /// The cost per conversion (including ecommerce and goal conversions) for your property.
        /// </summary>
        [FieldDataName("costPerConversion")]
        public Metric<double> CostPerConversion { get; set; }

        /// <summary>
        /// RPC or revenue-per-click is the average revenue (from ecommerce sales and/or goal value) you received for each click on one of your search ads.
        /// </summary>
        [FieldDataName("RPC")]
        public Metric<double> RPC { get; set; }

        /// <summary>
        /// Returns on Investment is overall transaction profit divided by derived advertising cost.
        /// </summary>
        [FieldDataName("ROI")]
        public Metric<double> ROI { get; set; }

        /// <summary>
        /// The overall transaction profit margin.
        /// </summary>
        [FieldDataName("margin")]
        public Metric<double> Margin { get; set; }
        #endregion

        #region Goal Conversions
        /// <summary>
        /// The total number of starts for the requested goal number.
        /// </summary>
        [FieldDataName("goal{0}Starts")]
        public Metric<int> GoalStarts(int n)
        {
            return (Metric<int>)getFieldForMethod("goal{0}Starts", n);
        }

        /// <summary>
        /// The total number of starts for all goals defined for your profile.
        /// </summary>
        [FieldDataName("goalStartsAll")]
        public Metric<int> GoalStartsAll { get; set; }

        /// <summary>
        /// The total number of completions for the requested goal number.
        /// </summary>
        [FieldDataName("goal{0}Completions")]
        public Metric<int> GoalCompletions(int n)
        {
            return (Metric<int>)getFieldForMethod("goal{0}Completions", n);
        }

        /// <summary>
        /// The total number of completions for all goals defined for your profile.
        /// </summary>
        [FieldDataName("goalCompletionsAll")]
        public Metric<int> GoalCompletionsAll { get; set; }

        /// <summary>
        /// The total numeric value for the requested goal number.
        /// </summary>
        [FieldDataName("goal{0}Value")]
        public Metric<double> GoalValue(int n)
        {
            return (Metric<double>)getFieldForMethod("goal{0}Value", n);
        }

        /// <summary>
        /// The total numeric value for all goals defined for your profile.
        /// </summary>
        [FieldDataName("goalValueAll")]
        public Metric<double> GoalValueAll { get; set; }

        /// <summary>
        /// The average goal value of a visit to your property.
        /// </summary>
        [FieldDataName("goalValuePerVisit")]
        public Metric<double> GoalValuePerVisit { get; set; }

        /// <summary>
        /// The percentage of visits which resulted in a conversion to the requested goal number.
        /// </summary>
        [FieldDataName("goal{0}ConversionRate")]
        public Metric<double> GoalConversionRate(int n)
        {
            return (Metric<double>)getFieldForMethod("goal{0}ConversionRate", n);
        }

        /// <summary>
        /// The percentage of visits which resulted in a conversion to at least one of your goals.
        /// </summary>
        [FieldDataName("goalConversionRateAll")]
        public Metric<double> GoalConversionRateAll { get; set; }

        /// <summary>
        /// The number of times visitors started conversion activity on the requested goal number without actually completing it.
        /// </summary>
        [FieldDataName("goal{0}Abandons")]
        public Metric<int> GoalAbandons(int n)
        {
            return (Metric<int>)getFieldForMethod("goal{0}Abandons", n);
        }
        /// <summary>
        /// The overall number of times visitors started goals without actually completing them.
        /// </summary>
        [FieldDataName("goalAbandonsAll")]
        public Metric<int> GoalAbandonsAll { get; set; }

        /// <summary>
        /// The rate at which the requested goal number was abandoned.
        /// </summary>
        [FieldDataName("goal{0}AbandonRate")]
        public Metric<double> GoalAbandonRate(int n)
        {
            return (Metric<double>)getFieldForMethod("goal{0}AbandonRate", n);
        }

        /// <summary>
        /// The rate at which goals were abandoned.
        /// </summary>
        [FieldDataName("goalAbandonRateAll")]
        public Metric<double> GoalAbandonRateAll { get; set; }
        #endregion

        #region Platform / Device
        /// <summary>
        /// The names of browsers used by visitors to your website. For example, Internet Explorer or Firefox.
        /// </summary>
        [FieldDataName("browser")]
        public Dimension<string> Browser { get; set; }

        /// <summary>
        /// The browser versions used by visitors to your website. For example, 2.0.0.14
        /// </summary>
        [FieldDataName("browserVersion")]
        public Dimension<string> BrowserVersion { get; set; }

        /// <summary>
        /// The operating system used by your visitors. For example, Windows, Linux , Macintosh, iPhone, iPod.
        /// </summary>
        [FieldDataName("operatingSystem")]
        public Dimension<string> OperatingSystem { get; set; }

        /// <summary>
        /// The version of the operating system used by your visitors, such as XP for Windows or PPC for Macintosh.
        /// </summary>
        [FieldDataName("operatingSystemVersion")]
        public Dimension<string> OperatingSystemVersion { get; set; }

        /// <summary>
        /// Indicates mobile visitors. The possible values are Yes or No where the first letter must be capitalized.
        /// </summary>
        [FieldDataName("isMobile")]
        public YesNoBoolDimension IsMobile { get; set; }

        /// <summary>
        /// Mobile manufacturer or branded name (e.g: Samsung, HTC, Verizon, T-Mobile).
        /// </summary>
        [FieldDataName("mobileDeviceBranding")]
        public Dimension<string> MobileDeviceBranding { get; set; }

        /// <summary>
        /// Mobile device model (e.g.: Nexus S)
        /// </summary>
        [FieldDataName("mobileDeviceModel")]
        public Dimension<string> MobileDeviceModel { get; set; }

        /// <summary>
        /// Selector used on the mobile device (e.g.: touchscreen, joystick, clickwheel, stylus).
        /// </summary>
        [FieldDataName("mobileInputSelector")]
        public Dimension<string> MobileInputSelector { get; set; }

        /// <summary>
        /// The branding, model, and marketing name used to identify the mobile device.
        /// </summary>
        [FieldDataName("mobileDeviceInfo")]
        public Dimension<string> MobileDeviceInfo { get; set; }
        #endregion

        #region Geo / Network
        /// <summary>
        /// The continents of property visitors, derived from IP addresses.
        /// </summary>
        [FieldDataName("continent")]
        public Dimension<string> Continent { get; set; }

        /// <summary>
        /// The sub-continent of visitors, derived from IP addresses. For example, Polynesia or Northern Europe.
        /// </summary>
        [FieldDataName("subContinent")]
        public Dimension<string> SubContinent { get; set; }

        /// <summary>
        /// The countries of website visitors, derived from IP addresses.
        /// </summary>
        [FieldDataName("country")]
        public Dimension<string> Country { get; set; }

        /// <summary>
        /// The region of visitors to your property, derived from IP addresses. In the U.S., a region is a state, such as New York.
        /// </summary>
        [FieldDataName("region")]
        public Dimension<string> Region { get; set; }

        /// <summary>
        /// The Designated Market Area (DMA) from where traffic arrived on your property.
        /// </summary>
        [FieldDataName("metro")]
        public Dimension<string> Metro { get; set; }

        /// <summary>
        /// The cities of property visitors, derived from IP addresses.
        /// </summary>
        [FieldDataName("city")]
        public Dimension<string> City { get; set; }

        /// <summary>
        /// The approximate latitude of the visitor's city. Derived from IP address. Locations north of the equator are represented by positive values and locations south of the equator by negative values.
        /// </summary>
        [FieldDataName("latitude")]
        public Dimension<double> Latitude { get; set; }

        /// <summary>
        /// The approximate longitude of the visitor's city. Derived from IP address. Locations east of the meridian are represented by positive values and locations west of the meridian by negative values.
        /// </summary>
        [FieldDataName("longitude")]
        public Dimension<double> Longitude { get; set; }

        /// <summary>
        /// The domain name of the ISPs used by visitors to your property. This is derived from the domain name registered to the IP address.
        /// </summary>
        [FieldDataName("networkDomain")]
        public Dimension<string> NetworkDomain { get; set; }

        /// <summary>
        /// The name of service providers used to reach your property. For example, if most visitors to your website come via the major service providers for cable internet, you will see the names of those cable service providers in this element.
        /// </summary>
        [FieldDataName("networkLocation")]
        public Dimension<string> NetworkLocation { get; set; }
        #endregion

        #region System
        /// <summary>
        /// The versions of Flash supported by visitors' browsers, including minor versions.
        /// </summary>
        [FieldDataName("flashVersion")]
        public Dimension<string> FlashVersion { get; set; }

        /// <summary>
        /// Indicates Java support for visitors' browsers. The possible values are Yes or No where the first letter must be capitalized.
        /// </summary>
        [FieldDataName("javaEnabled")]
        public Dimension<string> JavaEnabled { get; set; }

        /// <summary>
        /// The language provided by the HTTP Request for the browser. Values are given as an ISO-639 code (e.g. en-gb for British English).
        /// </summary>
        [FieldDataName("language")]
        public Dimension<string> Language { get; set; }

        /// <summary>
        /// The color depth of visitors' monitors, as retrieved from the DOM of the visitor's browser. For example 4-bit, 8-bit, 24-bit, or undefined-bit.
        /// </summary>
        [FieldDataName("screenColors")]
        public Dimension<string> ScreenColors { get; set; }

        /// <summary>
        /// The screen resolution of visitors' monitors, as retrieved from the DOM of the visitor's browser. For example: 1024x738.
        /// </summary>
        [FieldDataName("screenResolution")]
        public Dimension<string> ScreenResolution { get; set; }
        #endregion

        #region Social Activities
        /// <summary>
        /// For a social data hub activity, this value represents the URL of the social activity (e.g. the Google+ post URL, the blog comment URL, etc.)
        /// </summary>
        [FieldDataName("socialActivityEndorsingUrl")]
        public Dimension<string> SocialActivityEndorsingUrl { get; set; }

        /// <summary>
        /// For a social data hub activity, this value represents the title of the social activity posted by the social network user.
        /// </summary>
        [FieldDataName("socialActivityDisplayName")]
        public Dimension<string> SocialActivityDisplayName { get; set; }

        /// <summary>
        /// For a social data hub activity, this value represents the content of the social activity posted by the social network user (e.g. The message content of a Google+ post)
        /// </summary>
        [FieldDataName("socialActivityPost")]
        public Dimension<string> SocialActivityPost { get; set; }

        /// <summary>
        /// For a social data hub activity, this value represents when the social activity occurred on the social network.
        /// </summary>
        [FieldDataName("socialActivityTimestamp")]
        public Dimension<string> SocialActivityTimestamp { get; set; }

        /// <summary>
        /// For a social data hub activity, this value represents the social network handle (e.g. name or ID) of the user who initiated the social activity.
        /// </summary>
        [FieldDataName("socialActivityUserHandle")]
        public Dimension<string> SocialActivityUserHandle { get; set; }

        /// <summary>
        /// For a social data hub activity, this value represents the URL of the photo associated with the user's social network profile.
        /// </summary>
        [FieldDataName("socialActivityUserPhotoUrl")]
        public Dimension<string> SocialActivityUserPhotoUrl { get; set; }

        /// <summary>
        /// For a social data hub activity, this value represents the URL of the associated user's social network profile.
        /// </summary>
        [FieldDataName("socialActivityUserProfileUrl")]
        public Dimension<string> SocialActivityUserProfileUrl { get; set; }

        /// <summary>
        /// For a social data hub activity, this value represents the URL shared by the associated social network user.
        /// </summary>
        [FieldDataName("socialActivityContentUrl")]
        public Dimension<string> SocialActivityContentUrl { get; set; }

        /// <summary>
        /// For a social data hub activity, this is a comma-separated set of tags associated with the social activity.
        /// </summary>
        [FieldDataName("socialActivityTagsSummary")]
        public Dimension<string> SocialActivityTagsSummary { get; set; }

        /// <summary>
        /// For a social data hub activity, this value represents the type of social action associated with the activity (e.g. vote, comment, +1, etc.).
        /// </summary>
        [FieldDataName("socialActivityAction")]
        public Dimension<string> SocialActivityAction { get; set; }
        /// <summary>
        /// For a social data hub activity, this value represents the type of social action and the social network where the activity originated.
        /// </summary>
        [FieldDataName("socialActivityNetworkAction")]
        public Dimension<string> SocialActivityNetworkAction { get; set; }

        /// <summary>
        /// The count of activities where a content URL was shared / mentioned on a social data hub partner network.
        /// </summary>
        [FieldDataName("socialActivities")]
        public Metric<int> SocialActivities { get; set; }
        #endregion

        #region Page Tracking
        /// <summary>
        /// The hostname from which the tracking request was made.
        /// </summary>
        [FieldDataName("hostname")]
        public Dimension<string> Hostname { get; set; }

        /// <summary>
        /// A page on your website specified by path and/or query parameters. Use in conjunction with ga:hostname to get the full URL of the page.
        /// </summary>
        [FieldDataName("pagePath")]
        public AdSlotTypeDimension PagePath { get; set; }

        /// <summary>
        /// This dimension rolls up all the page paths in the first hierarchical level in ga:pagePath.
        /// </summary>
        [FieldDataName("pagePathLevel1")]
        public MediumTypeDimension PagePathLevel1 { get; set; }

        /// <summary>
        /// This dimension rolls up all the page paths in the second hierarchical level in ga:pagePath.
        /// </summary>
        [FieldDataName("pagePathLevel2")]
        public Dimension<string> PagePathLevel2 { get; set; }

        /// <summary>
        /// This dimension rolls up all the page paths in the third hierarchical level in ga:pagePath.
        /// </summary>
        [FieldDataName("pagePathLevel3")]
        public Dimension<string> PagePathLevel3 { get; set; }

        /// <summary>
        ///This dimension rolls up all the page paths in the fourth hierarchical level in ga:pagePath. All additional levels in the ga:pagePath hierarchy are also rolled up in this dimension.
        /// </summary>
        [FieldDataName("pagePathLevel4")]
        public Dimension<string> PagePathLevel4 { get; set; }

        /// <summary>
        /// The title of a page. Keep in mind that multiple pages might have the same page title.
        /// </summary>
        [FieldDataName("pageTitle")]
        public Dimension<string> PageTitle { get; set; }

        /// <summary>
        /// The first page in a user's session, or landing page.
        /// </summary>
        [FieldDataName("landingPagePath")]
        public Dimension<string> LandingPagePath { get; set; }

        /// <summary>
        /// The second page in a user's session.
        /// </summary>
        [FieldDataName("secondPagePath")]
        public Dimension<string> SecondPagePath { get; set; }

        /// <summary>
        /// The last page in a user's session, or exit page.
        /// </summary>
        [FieldDataName("exitPagePath")]
        public Dimension<string> ExitPagePath { get; set; }

        /// <summary>
        /// A page on your property that was visited before another page on the same property. Typically used with the ga:nextPagePath dimension.
        /// </summary>
        [FieldDataName("previousPagePath")]
        public Dimension<string> PreviousPagePath { get; set; }

        /// <summary>
        /// A page on your website that was visited after another page on your website. Typically used with the ga:previousPagePath dimension.
        /// </summary>
        [FieldDataName("nextPagePath")]
        public Dimension<string> NextPagePath { get; set; }

        /// <summary>
        /// The number of pages visited by visitors during a session (visit). The value is a histogram that counts pageviews across a range of possible values. In this calculation, all visits will have at least one pageview, and some percentage of visits will have more.
        /// </summary>
        [FieldDataName("pageDepth")]
        public Dimension<int> PageDepth { get; set; }

        /// <summary>
        /// The number of entrances to your property measured as the first pageview in a session. Typically used with ga:landingPagePath
        /// </summary>
        [FieldDataName("entrances")]
        public Metric<int> Entrances { get; set; }

        /// <summary>
        /// The total number of pageviews for your property.
        /// </summary>
        [FieldDataName("pageviews")]
        public Metric<int> Pageviews { get; set; }

        /// <summary>
        /// The number of different (unique) pages within a session. This takes into both the pagePath and pageTitle to determine uniqueness.
        /// </summary>
        [FieldDataName("uniquePageviews")]
        public Metric<int> UniquePageviews { get; set; }

        /// <summary>
        /// How long a visitor spent on a particular page in seconds. Calculated by subtracting the initial view time for a particular page from the initial view time for a subsequent page. Thus, this metric does not apply to exit pages for your property.
        /// </summary>
        [FieldDataName("timeOnPage")]
        public SecondsTimeSpanMetric timeOnPage { get; set; }

        /// <summary>
        /// The number of exits from your property.
        /// </summary>
        [FieldDataName("exits")]
        public Metric<int> Exits { get; set; }

        /// <summary>
        /// The percentage of pageviews in which this page was the entrance.
        /// </summary>
        [FieldDataName("entranceRate")]
        public Metric<double> EntranceRate { get; set; }

        /// <summary>
        /// The average number of pages viewed during a visit to your property. Repeated views of a single page are counted.
        /// </summary>
        [FieldDataName("pageviewsPerVisit")]
        public Metric<double> PageviewsPerVisit { get; set; }

        /// <summary>
        /// The average amount of time visitors spent viewing this page or a set of pages.
        /// </summary>
        [FieldDataName("avgTimeOnPage")]
        public Metric<double> AvgTimeOnPage { get; set; }

        /// <summary>
        /// The percentage of exits from your property that occurred out of the total page views.
        /// </summary>
        [FieldDataName("exitRate")]
        public Metric<double> ExitRate { get; set; }

        #endregion

        #region Internal Search
        /// <summary>
        /// A boolean to distinguish whether internal search was used in a session. Values are Visits With Site Search and Visits Without Site Search.
        /// </summary>
        [FieldDataName("searchUsed")]
        public Dimension<string> SearchUsed { get; set; }

        /// <summary>
        /// Search terms used by visitors within your property.
        /// </summary>
        [FieldDataName("searchKeyword")]
        public Dimension<string> SearchKeyword { get; set; }

        /// <summary>
        /// Subsequent keyword search terms or strings entered by users after a given initial string search.
        /// </summary>
        [FieldDataName("searchKeywordRefinement")]
        public Dimension<string> SearchKeywordRefinement { get; set; }

        /// <summary>
        /// The categories used for the internal search if you have this enabled for your profile. For example, you might have product categories such as electronics, furniture, or clothing.
        /// </summary>
        [FieldDataName("searchCategory")]
        public Dimension<string> SearchCategory { get; set; }

        /// <summary>
        /// This dimension rolls up all the page paths in the third hierarchical level in ga:pagePath.
        /// </summary>
        [FieldDataName("searchStartPage")]
        public Dimension<string> SearchStartPage { get; set; }

        /// <summary>
        /// A page that the user visited after performing an internal search on your property.
        /// </summary>
        [FieldDataName("searchDestinationPage")]
        public Dimension<string> SearchDestinationPage { get; set; }

        /// <summary>
        /// The number of times a search result page was viewed after performing a search.
        /// </summary>
        [FieldDataName("searchResultViews")]
        public Metric<int> SearchResultViews { get; set; }

        /// <summary>
        /// The total number of unique keywords from internal searches within a session. For example if "shoes" was searched for 3 times in a session, it will be only counted once.
        /// </summary>
        [FieldDataName("searchUniques")]
        public Metric<int> SearchUniques { get; set; }

        /// <summary>
        /// The total number of sessions that included an internal search
        /// </summary>
        [FieldDataName("searchVisits")]
        public Metric<int> SearchVisits { get; set; }

        /// <summary>
        /// The average number of subsequent page views made on your property after a use of your internal search feature.
        /// </summary>
        [FieldDataName("searchDepth")]
        public Metric<int> SearchDepth { get; set; }

        /// <summary>
        /// The total number of times a refinement (transition) occurs between internal search keywords within a session. For example if the sequence of keywords is: "shoes", "shoes", "pants", "pants", this metric will be one because the transition between "shoes" and "pants" is different.
        /// </summary>
        [FieldDataName("searchRefinements")]
        public Metric<int> SearchRefinements { get; set; }

        /// <summary>
        /// The visit duration to your property where a use of your internal search feature occurred.
        /// </summary>
        [FieldDataName("searchDuration")]
        public SecondsTimeSpanMetric SearchDuration { get; set; }

        /// <summary>
        /// The number of exits on your site that occurred following a search result from your internal search feature.
        /// </summary>
        [FieldDataName("searchExits")]
        public Metric<int> SearchExits { get; set; }

        /// <summary>
        /// The average number of times people viewed a search results page after performing a search.
        /// </summary>
        [FieldDataName("avgSearchResultViews")]
        public Metric<double> AvgSearchResultViews { get; set; }

        /// <summary>
        /// The percentage of exits from your property that occurred out of the total page views.
        /// </summary>
        [FieldDataName("percentVisitsWithSearch")]
        public Metric<double> PercentVisitsWithSearch { get; set; }

        /// <summary>
        /// The percentage of visits with search.
        /// </summary>
        [FieldDataName("avgSearchDepth")]
        public Metric<double> AvgSearchDepth { get; set; }

        /// <summary>
        /// The average amount of time people spent on your property after searching.
        /// </summary>
        [FieldDataName("avgSearchDuration")]
        public Metric<double> AvgSearchDuration { get; set; }

        /// <summary>
        /// The percentage of searches that resulted in an immediate exit from your property.
        /// </summary>
        [FieldDataName("searchExitRate")]
        public Metric<double> SearchExitRate { get; set; }

        /// <summary>
        /// The percentage of search visits (i.e., visits that included at least one search) which resulted in a conversion to the requested goal number.
        /// </summary>
        [FieldDataName("searchGoal{0}ConversionRate")]
        public Metric<double> SearchGoalConversionRate(int n)
        {
            return (Metric<double>)getFieldForMethod("searchGoal{0}ConversionRate", n);
        }

        /// <summary>
        /// The percentage of search visits (i.e., visits that included at least one search) which resulted in a conversion to at least one of your goals.
        /// </summary>
        [FieldDataName("searchGoalConversionRateAll")]
        public Metric<double> SearchGoalConversionRateAll { get; set; }

        /// <summary>
        /// The average goal value of a search on your property.
        /// </summary>
        [FieldDataName("goalValueAllPerSearch")]
        public Metric<double> GoalValueAllPerSearch { get; set; }

        #endregion

        #region Site Speed
        /// <summary>
        /// Total Page Load Time is the amount of time (in milliseconds) it takes for pages from the sample set to load, from initiation of the pageview (e.g. click on a page link) to load completion in the browser.
        /// </summary>
        [FieldDataName("pageLoadTime")]
        public MilisecondsTimeSpanMetric PageLoadTime { get; set; }

        /// <summary>
        /// The sample set (or count) of pageviews used to calculate the average page load time.
        /// </summary>
        [FieldDataName("pageLoadSample")]
        public Metric<int> PageLoadSample { get; set; }

        /// <summary>
        /// The total amount of time (in milliseconds) spent in DNS lookup for this page among all samples.
        /// </summary>
        [FieldDataName("domainLookupTime")]
        public MilisecondsTimeSpanMetric DomainLookupTime { get; set; }

        /// <summary>
        /// The total amount of time (in milliseconds) to download this page among all samples.
        /// </summary>
        [FieldDataName("pageDownloadTime")]
        public MilisecondsTimeSpanMetric PageDownloadTime { get; set; }

        /// <summary>
        /// The total amount of time (in milliseconds) spent in redirects before fetching this page among all samples. If there are no redirects, the value for this metric is expected to be 0.
        /// </summary>
        [FieldDataName("redirectionTime")]
        public MilisecondsTimeSpanMetric RedirectionTime { get; set; }

        /// <summary>
        /// The total amount of time (in milliseconds) spent in establishing TCP connection for this page among all samples.
        /// </summary>
        [FieldDataName("serverConnectionTime")]
        public MilisecondsTimeSpanMetric ServerConnectionTime { get; set; }

        /// <summary>
        /// The total amount of time (in milliseconds) your server takes to respond to a user request among all samples, including the network time from user's location to your server.
        /// </summary>
        [FieldDataName("serverResponseTime")]
        public MilisecondsTimeSpanMetric ServerResponseTime { get; set; }

        /// <summary>
        /// The sample set (or count) of pageviews used to calculate the averages for site speed metrics. This metric is used in all site speed average calculations including ga:avgDomainLookupTime, ga:avgPageDownloadTime, ga:avgRedirectionTime, ga:avgServerConnectionTime, and ga:avgServerResponseTime.
        /// </summary>
        [FieldDataName("speedMetricsSample")]
        public Metric<int> SpeedMetricsSample { get; set; }

        /// <summary>
        /// The time the browser takes (in milliseconds) to parse the document (DOMInteractive), including the network time from the user's location to your server. At this time, the user can interact with the Document Object Model even though it is not fully loaded.
        /// </summary>
        [FieldDataName("domInteractiveTime")]
        public MilisecondsTimeSpanMetric DomInteractiveTime { get; set; }

        /// <summary>
        /// The time the browser takes (in milliseconds) to parse the document and execute deferred and parser-inserted scripts (DOMContentLoaded), including the network time from the user's location to your server. Parsing of the document is finished, the Document Object Model is ready, but referenced style sheets, images, and subframes may not be finished loading. This event is often the starting point for javascript framework execution, e.g., JQuery's onready() callback, etc.
        /// </summary>
        [FieldDataName("domContentLoadedTime")]
        public MilisecondsTimeSpanMetric DomContentLoadedTime { get; set; }

        /// <summary>
        /// The sample set (or count) of pageviews used to calculate the averages for site speed DOM metrics. This metric is used in the ga:avgDomContentLoadedTime and ga:avgDomInteractiveTime calculations.
        /// </summary>
        [FieldDataName("domLatencyMetricsSample")]
        public Metric<int> DomLatencyMetricsSample { get; set; }

        /// <summary>
        /// The average amount of time (in seconds) it takes for pages from the sample set to load, from initiation of the pageview (e.g. click on a page link) to load completion in the browser.
        /// </summary>
        [FieldDataName("avgPageLoadTime")]
        public SecondsTimeSpanMetric AvgPageLoadTime { get; set; }

        /// <summary>
        /// The average amount of time (in seconds) spent in DNS lookup for this page.
        /// </summary>
        [FieldDataName("avgDomainLookupTime")]
        public SecondsTimeSpanMetric AvgDomainLookupTime { get; set; }

        /// <summary>
        /// The average amount of time (in seconds) to download this page.
        /// </summary>
        [FieldDataName("avgPageDownloadTime")]
        public SecondsTimeSpanMetric AvgPageDownloadTime { get; set; }

        /// <summary>
        /// The average amount of time (in seconds) spent in redirects before fetching this page. If there are no redirects, the value for this metric is expected to be 0.
        /// </summary>
        [FieldDataName("avgRedirectionTime")]
        public SecondsTimeSpanMetric AvgRedirectionTime { get; set; }

        /// <summary>
        /// The average amount of time (in seconds) spent in establishing TCP connection for this page.
        /// </summary>
        [FieldDataName("avgServerConnectionTime")]
        public SecondsTimeSpanMetric AvgServerConnectionTime { get; set; }

        /// <summary>
        /// The average amount of time (in seconds) your server takes to respond to a user request, including the network time from user's location to your server.
        /// </summary>
        [FieldDataName("avgServerResponseTime")]
        public SecondsTimeSpanMetric AvgServerResponseTime { get; set; }

        /// <summary>
        /// The average time (in seconds) it takes the browser to parse the document and execute deferred and parser-inserted scripts including the network time from the user's location to your server.
        /// </summary>
        [FieldDataName("avgDomInteractiveTime")]
        public SecondsTimeSpanMetric AvgDomInteractiveTime { get; set; }

        /// <summary>
        /// The average time (in seconds) it takes the browser to parse the document.
        /// </summary>
        [FieldDataName("avgDomContentLoadedTime")]
        public SecondsTimeSpanMetric AvgDomContentLoadedTime { get; set; }

        #endregion

        #region App Tracking
        /// <summary>
        /// The total number of app views.
        /// </summary>
        [FieldDataName("appviews")]
        public Metric<int> Appviews { get; set; }

        /// <summary>
        /// The number of different (unique) ga:appviews within a session.
        /// </summary>
        [FieldDataName("uniqueAppviews")]
        public Metric<int> UniqueAppviews { get; set; }

        /// <summary>
        /// The average number of ga:appviews per session.
        /// </summary>
        [FieldDataName("appviewsPerVisit")]
        public Metric<double> AppviewsPerVisit { get; set; }
        #endregion

        #region Event Tracking
        /// <summary>
        /// The category of the event.
        /// </summary>
        [FieldDataName("eventCategory")]
        public Dimension<string> EventCategory { get; set; }

        /// <summary>
        /// The action of the event.
        /// </summary>
        [FieldDataName("eventAction")]
        public Dimension<string> EventAction { get; set; }

        /// <summary>
        /// The label of the event.
        /// </summary>
        [FieldDataName("eventLabel")]
        public Dimension<string> EventLabel { get; set; }

        /// <summary>
        /// The total number of events for the profile, across all categories.
        /// </summary>
        [FieldDataName("totalEvents")]
        public Metric<int> TotalEvents { get; set; }

        /// <summary>
        /// The total number of unique events for the profile, across all categories.
        /// </summary>
        [FieldDataName("uniqueEvents")]
        public Metric<int> UniqueEvents { get; set; }

        /// <summary>
        /// The total value of events for the profile.
        /// </summary>
        [FieldDataName("eventValue")]
        public Metric<int> EventValue { get; set; }

        /// <summary>
        /// The total number of visits with events.
        /// </summary>
        [FieldDataName("visitsWithEvent")]
        public Metric<int> VisitsWithEvent { get; set; }

        /// <summary>
        /// The average value of an event.
        /// </summary>
        [FieldDataName("avgEventValue")]
        public Metric<double> AvgEventValue { get; set; }

        /// <summary>
        /// The average number of events per visit with event.
        /// </summary>
        [FieldDataName("eventsPerVisitWithEvent")]
        public Metric<double> EventsPerVisitWithEvent { get; set; }
        #endregion

        #region Ecommerce
        /// <summary>
        /// The transaction ID for the shopping cart purchase as supplied by your ecommerce tracking method.
        /// </summary>
        [FieldDataName("transactionId")]
        public Dimension<string> TransactionId { get; set; }

        /// <summary>
        /// Typically used to designate a supplying company or brick and mortar location; product affiliation.
        /// </summary>
        [FieldDataName("affiliation")]
        public Dimension<string> Affiliation { get; set; }

        /// <summary>
        /// The number of visits between users' purchases and the related campaigns that lead to the purchases.
        /// </summary>
        [FieldDataName("visitsToTransaction")]
        public Dimension<int> VisitsToTransaction { get; set; }

        /// <summary>
        /// The number of days between users' purchases and the related campaigns that lead to the purchases.
        /// </summary>
        [FieldDataName("daysToTransaction")]
        public Dimension<int> DaysToTransaction { get; set; }

        /// <summary>
        /// The product sku for purchased items as you have defined them in your ecommerce tracking application.
        /// </summary>
        [FieldDataName("productSku")]
        public Dimension<string> ProductSku { get; set; }

        /// <summary>
        /// The product name for purchased items as supplied by your ecommerce tracking application.
        /// </summary>
        [FieldDataName("productName")]
        public Dimension<string> ProductName { get; set; }

        /// <summary>
        /// Any product variations (size, color) for purchased items as supplied by your ecommerce application.
        /// </summary>
        [FieldDataName("productCategory")]
        public Dimension<string> ProductCategory { get; set; }

        /// <summary>
        /// The total number of transactions.
        /// </summary>
        [FieldDataName("transactions")]
        public Metric<int> Transactions { get; set; }

        /// <summary>
        /// The total sale revenue provided in the transaction excluding shipping and tax.
        /// </summary>
        [FieldDataName("transactionRevenue")]
        public Metric<int> TransactionRevenue { get; set; }

        /// <summary>
        /// The total cost of shipping.
        /// </summary>
        [FieldDataName("transactionShipping")]
        public Metric<int> TransactionShipping { get; set; }

        /// <summary>
        /// The total amount of tax.
        /// </summary>
        [FieldDataName("transactionTax")]
        public Metric<int> TransactionTax { get; set; }

        /// <summary>
        /// The total number of items purchased. For example, if users purchase 2 frisbees and 5 tennis balls, 7 items have been purchased.
        /// </summary>
        [FieldDataName("itemQuantity")]
        public Metric<int> ItemQuantity { get; set; }

        /// <summary>
        /// The number of product sets purchased. For example, if users purchase 2 frisbees and 5 tennis balls from your site, 2 unique products have been purchased.
        /// </summary>
        [FieldDataName("uniquePurchases")]
        public Metric<int> UniquePurchases { get; set; }

        /// <summary>
        /// The total revenue from purchased product items on your property.
        /// </summary>
        [FieldDataName("itemRevenue")]
        public Metric<int> ItemRevenue { get; set; }

        /// <summary>
        /// The average number of transactions for a visit to your property.
        /// </summary>
        [FieldDataName("transactionsPerVisit")]
        public Metric<int> TransactionsPerVisit { get; set; }

        /// <summary>
        /// The average revenue for an e-commerce transaction.
        /// </summary>
        [FieldDataName("revenuePerTransaction")]
        public Metric<int> RevenuePerTransaction { get; set; }

        /// <summary>
        /// Average transaction revenue for a visit to your property.
        /// </summary>
        [FieldDataName("transactionRevenuePerVisit")]
        public Metric<int> TransactionRevenuePerVisit { get; set; }

        /// <summary>
        /// Total value for your property (including total revenue and total goal value).
        /// </summary>
        [FieldDataName("totalValue")]
        public Metric<int> TotalValue { get; set; }

        /// <summary>
        /// The average revenue per item.
        /// </summary>
        [FieldDataName("revenuePerItem")]
        public Metric<int> RevenuePerItem { get; set; }

        /// <summary>
        /// The average quantity of this item (or group of items) sold per purchase.
        /// </summary>
        [FieldDataName("itemsPerPurchase")]
        public Metric<int> ItemsPerPurchase { get; set; }
        #endregion

        #region Social Interactions
        /// <summary>
        /// For social interactions, a value representing the social network being tracked (e.g. Google, Facebook, Twitter, LinkedIn)
        /// </summary>
        [FieldDataName("socialInteractionNetwork")]
        public Dimension<string> SocialInteractionNetwork { get; set; }

        /// <summary>
        /// For social interactions, a value representing the social action being tracked (e.g. +1, like, bookmark)
        /// </summary>
        [FieldDataName("socialInteractionAction")]
        public Dimension<string> SocialInteractionAction { get; set; }

        /// <summary>
        /// For social interactions, a value representing the concatenation of the ga:socialInteractionNetwork and ga:socialInteractionAction action being tracked (e.g. Google: +1, Facebook: like)
        /// </summary>
        [FieldDataName("socialInteractionNetworkAction")]
        public Dimension<string> SocialInteractionNetworkAction { get; set; }

        /// <summary>
        /// For social interactions, a value representing the URL (or resource) which receives the social network action.
        /// </summary>
        [FieldDataName("socialInteractionTarget")]
        public Dimension<string> SocialInteractionTarget { get; set; }

        /// <summary>
        /// The total number of social interactions on your property.
        /// </summary>
        [FieldDataName("socialInteractions")]
        public Metric<int> SocialInteractions { get; set; }

        /// <summary>
        /// The number of sessions during which the specified social action(s) occurred at least once. This is based on the the unique combination of ga:socialInteractionNetwork, ga:socialInteractionAction, and ga:socialInteractionTarget.
        /// </summary>
        [FieldDataName("uniqueSocialInteractions")]
        public Metric<int> UniqueSocialInteractions { get; set; }

        /// <summary>
        /// The number of social interactions per visit to your property.
        /// </summary>
        [FieldDataName("socialInteractionsPerVisit")]
        public Metric<double> SocialInteractionsPerVisit { get; set; }
        #endregion

        #region User Timings
        /// <summary>
        /// A string for categorizing all user timing variables into logical groups for easier reporting purposes.
        /// </summary>
        [FieldDataName("userTimingCategory")]
        public Dimension<string> UserTimingCategory { get; set; }

        /// <summary>
        /// The name of the resource's action being tracked.
        /// </summary>
        [FieldDataName("userTimingLabel")]
        public Dimension<string> UserTimingLabel { get; set; }

        /// <summary>
        /// A value that can be used to add flexibility in visualizing user timings in the reports.
        /// </summary>
        [FieldDataName("userTimingVariable")]
        public Dimension<string> UserTimingVariable { get; set; }

        /// <summary>
        /// The total number of milliseconds for a user timing.
        /// </summary>
        [FieldDataName("userTimingValue")]
        public Metric<int> UserTimingValue { get; set; }

        /// <summary>
        /// The number of hits that were sent for a particular ga:userTimingCategory, ga:userTimingLabel, and ga:userTimingVariable.
        /// </summary>
        [FieldDataName("userTimingSample")]
        public Metric<int> UserTimingSample { get; set; }

        /// <summary>
        /// The average amount of elapsed time.
        /// </summary>
        [FieldDataName("avgUserTimingValue")]
        public Metric<double> AvgUserTimingValue { get; set; }
        #endregion

        #region Exception Tracking
        /// <summary>
        /// The number of exceptions that were sent to Google Analytics.
        /// </summary>
        [FieldDataName("exceptions")]
        public Metric<int> Exceptions { get; set; }

        /// <summary>
        /// The number of exceptions where isFatal is set to true.
        /// </summary>
        [FieldDataName("fatalExceptions")]
        public Metric<int> FatalExceptions { get; set; }
        #endregion

        #region Experiments
        /// <summary>
        /// The id of the content experiment that the user was exposed to when the metrics were reported.
        /// </summary>
        [FieldDataName("experimentId")]
        public Dimension<string> ExperimentId { get; set; }

        /// <summary>
        /// The id of the particular variation that the user was exposed to during a content experiment.
        /// </summary>
        [FieldDataName("experimentVariant")]
        public Dimension<string> ExperimentVariant { get; set; }
        #endregion

        #region Custom Variables
        /// <summary>
        /// The name for the requested custom variable.
        /// </summary>
        [FieldDataName("customVarName{0}")]
        public Dimension<string> CustomVarName(string n)
        {
            return (Dimension<string>)getFieldForMethod("customVarName{0}", n);
        }

        /// <summary>
        /// The value for the requested custom variable.
        /// </summary>
        [FieldDataName("customVarValue{0}")]
        public Dimension<string> CustomVarValue(string n)
        {
            return (Dimension<string>)getFieldForMethod("customVarValue{0}", n);
        }
        #endregion

        #region Time
        /// <summary>
        /// The date of the visit.
        /// </summary>
        [FieldDataName("date")]
        public DateTimeDimension Date { get; set; }

        /// <summary>
        /// The year of the visit. A four-digit year from 2005 to the current year.
        /// </summary>
        [FieldDataName("year")]
        public Dimension<int> Year { get; set; }

        /// <summary>
        /// The month of the visit. A two digit integer from 01 to 12.
        /// </summary>
        [FieldDataName("month")]
        public Dimension<int> Month { get; set; }

        /// <summary>
        /// The week of the visit. A two-digit number from 01 to 53. Each week starts on Sunday.
        /// </summary>
        [FieldDataName("week")]
        public Metric<int> Week { get; set; }

        /// <summary>
        /// The day of the month. A two-digit number from 01 to 31.
        /// </summary>
        [FieldDataName("day")]
        public Metric<int> Day { get; set; }

        /// <summary>
        /// A two-digit hour of the day ranging from 00-23 in the timezone configured for the account. This value is also corrected for daylight savings time, adhering to all local rules for daylight savings time. If your timezone follows daylight savings time, there will be an apparent bump in the number of visits during the change-over hour (e.g. between 1:00 and 2:00) for the day per year when that hour repeats. A corresponding hour with zero visits will occur at the opposite changeover. (Google Analytics does not track visitor time more precisely than hours.)
        /// </summary>
        [FieldDataName("hour")]
        public Metric<int> Hour { get; set; }

        /// <summary>
        /// Index for each month in the specified date range. Index for the first month in the date range is 0, 1 for the second month, and so on. The index corresponds to ga:month entries.
        /// </summary>
        [FieldDataName("nthMonth")]
        public Metric<int> NthMonth { get; set; }

        /// <summary>
        /// Index for each week in the specified date range. Index for the first week in the date range is 0, 1 for the second week, and so on. The index corresponds to ga:week entries.
        /// </summary>
        [FieldDataName("nthWeek")]
        public Metric<int> NthWeek { get; set; }

        /// <summary>
        /// Index for each day in the specified date range. Index for the first day (i.e., start-date) in the date range is 0, 1 for the second day, and so on.
        /// </summary>
        [FieldDataName("nthDay")]
        public Metric<int> NthDay { get; set; }

        /// <summary>
        /// The day of the week.
        /// </summary>
        [FieldDataName("dayOfWeek")]
        public DayOfWeekMetric DayOfWeek { get; set; }
        #endregion

        #region private
        /// <summary>
        /// The storage of method names (which are used as Google Analytics fields) and data fields (Dimensions or Metrics).
        /// </summary>
        private Dictionary<string, BaseField> fieldsForMethodStorage = new Dictionary<string, BaseField>();

        /// <summary>
        /// Returns the data field (Dimension or Metric) by Google Analytics field name and input parameters
        /// </summary>
        /// <param name="fieldName">Google Analytics field name</param>
        /// <param name="n">Input method parameters</param>
        /// <returns>Data field (Dimension or Metric)</returns>
        private BaseField getFieldForMethod(string fieldName, params object[] n)
        {
            return fieldsForMethodStorage[string.Format(Constants.GOOGLE_ANALYTICS_PREFIX + fieldName, n)];
        }

        /// <summary>
        /// ONLY FOR REFLECTION. The invokation of this method will add the data field (Dimension or Metric) and key (Google Analytics field name) to the storage. 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        private void addTofieldsForMethodStorage(string fieldName, BaseField value)
        {
            if (!fieldsForMethodStorage.ContainsKey(fieldName))
            {
                fieldsForMethodStorage.Add(fieldName, value);
            }
        }
        #endregion
    }
}
