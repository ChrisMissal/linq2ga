using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleAnalyticsLinqProvider.Attributes;
using GoogleAnalyticsLinqProvider.Enums;
using System.Collections;
using System.Linq.Expressions;
using GoogleAnalyticsLinqProvider.Parsers;
using Google.Apis.Analytics.v3;
using Google.Apis.Analytics.v3.Data;
using Google.Apis.Requests;
using System.Reflection;

namespace GoogleAnalyticsLinqProvider.Core
{
    /// <summary>
    /// Initial Google Analytics data context
    /// </summary>
    public class DataContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="profileId">Google analytics profile ID</param>
        /// <param name="service">AnalyticsService object</param>
        public DataContext(string profileId, AnalyticsService service)
        {
            _queryData = new QueryData() { ProfileId = profileId, Service = service };
        }

        #region private
        /// <summary>
        /// Contains all necessary data for Google Analytics request 
        /// </summary>
        private QueryData _queryData;
        #endregion

        /// <summary>
        /// Returns the Created data context
        /// </summary>
        /// <param name="from">Report start date</param>
        /// <param name="to">Report end date</param>
        /// <returns>Created data context</returns>
        public CreatedDataContext Create(DateTime from, DateTime to)
        {
            _queryData.Reset();
            _queryData.To = to;
            _queryData.From = from;
            return new CreatedDataContext(_queryData);
        }
    }
}