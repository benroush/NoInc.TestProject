namespace NoInc.DataAccess.Models
{
    public partial class InterestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsCurrent { get; set; }
        public string Detail { get; set; }
    }
}