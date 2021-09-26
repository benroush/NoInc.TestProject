using AutoMapper;
using NoInc.TestProject.Models.Requests;
using NoInc.TestProject.Models.Responses;
using System;

namespace NoInc.TestProject.MappingProfiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<BusinessLogic.Models.Skill, GetSkillResponse>()
                .ConvertUsing(source => new GetSkillResponse(source.Id, source.Name, source.Type, source.DateLearned, source.Detail));

            CreateMap<CreateSkillRequest, BusinessLogic.Models.Skill>()
                .ConvertUsing(source => new BusinessLogic.Models.Skill(source.Name, (Enums.SkillType)Enum.Parse(typeof(Enums.SkillType), source.Type), source.DateLearned, source.Detail));
        }
    }
}