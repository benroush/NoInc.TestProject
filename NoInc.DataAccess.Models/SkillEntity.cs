using System;

namespace NoInc.DataAccess.Models
{
    public partial class SkillEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime DateLearned { get; set; }
        public string Detail { get; set; }
    }
}