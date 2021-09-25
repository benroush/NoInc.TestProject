using System;

namespace NoInc.TestProject.Models.Responses
{
    public class GetSkillResponse
    {
        public GetSkillResponse()
        {
        }
        
        public GetSkillResponse(int id, string name, Enums.SkillType type, DateTime dateLearned, string detail)
        {
            Id = id;
            Name = name;
            Type = type.ToString();
            DateLearned = dateLearned.ToShortDateString();
            Detail = detail;
        }

        public int Id { get; }
        public string Name { get; }
        public string Type { get; }
        public string DateLearned { get; }
        public string Detail { get; }
    }
}