namespace HCalc.WebUI.Models
{
    public class MatrixViewModel
    {
        public int Id { get; set; }
        public double? BuildingPartCode { get; set; }
        public string BuildingPartText { get; set; }
        public string  DefectDescriptionText { get; set; }
        public int Gebr { get; set; }
        public int Intencity { get; set; }
        public int Omvang { get; set; }
        public int Condition { get; set; }
        public string Action { get; set; }
        public int CountHvh { get; set; }
        public string Eenh { get; set; }
        public string Percent { get; set; }
        public int Cost { get; set; }
        public int Total { get; set; }
        public int BTW { get; set; }
        public int Cycle { get; set; }
        public int StartYear { get; set; }
        public string CalendarBuilder { get; set; }
    }
}