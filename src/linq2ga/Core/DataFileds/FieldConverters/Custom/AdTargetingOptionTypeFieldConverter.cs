using linq2ga.Enums;

namespace linq2ga.Core.DataFields
{
    internal class AdTargetingOptionTypeFieldConverter : IFieldConverter<AdTargetingOptionType>
    {
        const string AUTOMATIC_PLACEMENTS = "Automatic placements";
        const string MANAGED_PLACEMENTS = "Managed placements";

        public AdTargetingOptionType GetValue(string value)
        {
            AdTargetingOptionType result = 0;
            switch (value)
            {
                case AUTOMATIC_PLACEMENTS:
                    result = AdTargetingOptionType.AutomaticPlacements;
                    break;
                case MANAGED_PLACEMENTS:
                    result = AdTargetingOptionType.ManagedPlacements;
                    break;
            }
            return result;
        }

        public string GetStringValue(AdTargetingOptionType value)
        {
            string result = null;
            switch (value)
            {
                case AdTargetingOptionType.AutomaticPlacements:
                    result = AUTOMATIC_PLACEMENTS;
                    break;
                case AdTargetingOptionType.ManagedPlacements:
                    result = MANAGED_PLACEMENTS;
                    break;
            }
            return result;
        }
    }
}
