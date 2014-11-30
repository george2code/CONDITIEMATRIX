using System;

namespace HCalc.Domain.Entities
{
    public class Matrix
    {
        public int Id { get; set; }
        public Nullable<int> BuildingPartId { get; set; }
        public Nullable<int> DefectDescriptionId { get; set; }
        public int ImportanceId { get; set; }
        public int IntencityId { get; set; }
        public int ExtentId { get; set; }
        public int Condition { get; set; }
        public Nullable<int> ActieId { get; set; }
        public int HvhId { get; set; }
        public int EenhId { get; set; }
        public float? Percent { get; set; }
        public int Cost { get; set; }
        public Nullable<int> Total { get; set; }
        public int BTW { get; set; }
        public int Cycle { get; set; }
        public int StartYear { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
    }
}