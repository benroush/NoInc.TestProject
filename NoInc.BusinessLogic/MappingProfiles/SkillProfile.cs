using AutoMapper;
using NoInc.Enums;
using System;

namespace NoInc.BusinessLogic.MappingProfiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<DataAccess.Models.SkillEntity, Models.Skill>()
                .ConvertUsing(source => new Models.Skill(source.Id, source.Name, (SkillType)Enum.Parse(typeof(SkillType), source.Type), source.DateLearned, source.Detail));

            CreateMap<Models.Skill, DataAccess.Models.SkillEntity>()
                .ForMember(destination => destination.Type, opt => opt.MapFrom(source => source.Type.ToString()));
        }
    }
}