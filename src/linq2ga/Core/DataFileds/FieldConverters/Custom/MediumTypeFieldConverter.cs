using linq2ga.Enums;

namespace linq2ga.Core.DataFields
{
    internal class MediumTypeFieldConverter : IFieldConverter<MediumType>
    {
        const string AD_WORDS = "ppc";
        const string SEARCH_ENGINE = "organic";
        const string REFERRAL = "referral";
        const string NONE = "(none)";

        public MediumType GetValue(string value)
        {
            MediumType result;
            switch (value)
            {
                case AD_WORDS:
                    result = MediumType.AdWords;
                    break;
                case SEARCH_ENGINE:
                    result = MediumType.SearchEngine;
                    break;
                case REFERRAL:
                    result = MediumType.Referral;
                    break;
                case NONE:
                    result = MediumType.None;
                    break;
                default:
                    result = MediumType.Manual;
                    break;
            }
            return result;
        }

        public string GetStringValue(MediumType value)
        {
            string result = null;
            switch (value)
            {
                case MediumType.AdWords:
                    result = AD_WORDS;
                    break;
                case MediumType.SearchEngine:
                    result = SEARCH_ENGINE;
                    break;
                case MediumType.Referral:
                    result = REFERRAL;
                    break;
                case MediumType.None:
                    result = NONE;
                    break;
            }
            return result;
        }
    }
}
