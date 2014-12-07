using HCalc.Domain.Enums;

namespace HCalc.Domain.Entities
{
    public class ExtentTable
    {
        public int Value { get; set; }
        public ImportanceType Importance { get; set; }

        public ExtentTable(int value, ImportanceType type)
        {
            Value = value;
            Importance = type;
        }
    }
}
