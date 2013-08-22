using linq2ga.Enums;

namespace linq2ga.Core.DataFields
{
    internal class AdSlotTypeFieldConverter : IFieldConverter<AdSlotType>
    {
        const string TOP = "Top";
        const string RHS = "RHS";
        const string NOT_SET = "not set";

        public AdSlotType GetValue(string value)
        {
            AdSlotType result = 0;
            switch (value)
            {
                case TOP:
                    result = AdSlotType.Top;
                    break;
                case RHS:
                    result = AdSlotType.RHS;
                    break;
                case NOT_SET:
                default:
                    result = AdSlotType.NotSet;
                    break;
            }
            return result;
        }

        public string GetStringValue(AdSlotType value)
        {
            string result = null;
            switch (value)
            {
                case AdSlotType.Top:
                    result = TOP;
                    break;
                case AdSlotType.RHS:
                    result = RHS;
                    break;
                case AdSlotType.NotSet:
                default:
                    result = NOT_SET;
                    break;
            }
            return result;
        }
    }
}
