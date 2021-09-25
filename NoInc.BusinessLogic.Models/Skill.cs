using NoInc.Enums;
using System;

namespace NoInc.BusinessLogic.Models
{
    public class Skill
    {
        public Skill()
        {
        }

        public Skill(int id, string name, SkillType type, DateTime dateLearned, string detail)
        {
            Id = id;
            Name = name;
            Type = type;
            DateLearned = dateLearned;
            Detail = detail;
        }

        public Skill(string name, SkillType type, DateTime dateLearned, string detail)
        {
            Name = name;
            Type = type;
            DateLearned = dateLearned;
            Detail = detail;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public SkillType Type { get; set; }
        public DateTime DateLearned { get; set; }
        public string Detail { get; set; }
    }
}
