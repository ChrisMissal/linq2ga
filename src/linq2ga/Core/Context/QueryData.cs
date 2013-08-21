using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Analytics.v3;

namespace GoogleAnalyticsLinqProvider.Core
{
    /// <summary>
    /// Contains all necessary data for Google Analytics request
    /// </summary>
    public class QueryData
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public QueryData()
        {
            Metrics = new List<string>();
            Dimensions = new List<string>();
            Filters = new List<string>();
            SortingFields = new List<string>();
            DynamicSegments = new List<string>();
        }

        /// <summary>
        /// Google Analytics profile ID
        /// </summary>
        public string ProfileId { get; set; }

        /// <summary>
        /// AnalyticsService object
        /// </summary>
        public AnalyticsService Service { get; set; }

        /// <summary>
        /// The first date of the date range for which you are requesting the data.
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// The last date of the date range for which you are requesting the data.
        /// </summary>
        public DateTime To { get; set; }

        /// <summary>
        /// The count of skipped results
        /// </summary>
        public long? Skip { get; set; }

        /// <summary>
        /// The count of taken results
        /// </summary>
        public long? Take { get; set; }

        /// <summary>
        /// The list of metrics
        /// </summary>
        public List<string> Metrics { get; private set; }

        /// <summary>
        /// The list of dimension
        /// </summary>
        public List<string> Dimensions { get; private set; }

        /// <summary>
        /// The list of filter expressions
        /// </summary>
        public List<string> Filters { get; private set; }

        /// <summary>
        /// Segment ID
        /// </summary>
        public string SegmentId { get; set; }

        /// <summary>
        /// The list of dynamic segment expressios
        /// </summary>
        public List<string> DynamicSegments { get; private set; }

        /// <summary>
        /// The list of sorting fields
        /// </summary>
        public List<string> SortingFields { get; private set; }

        /// <summary>
        /// Reset query data
        /// </summary>
        public void Reset()
        {
            Metrics.Clear();
            Dimensions.Clear();
            Filters.Clear();
            SortingFields.Clear();
            DynamicSegments.Clear();
            Take = null;
            Skip = null;
            SegmentId = null;
        }

        /// <summary>
        /// Reset metrics and dimensions
        /// </summary>
        public void ResetMetricsAndDimensions()
        {
            Metrics.Clear();
            Dimensions.Clear();
        }
    }
}
