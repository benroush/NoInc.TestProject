using AutoMapper;
using NoInc.Enums;
using System;

namespace NoInc.BusinessLogic.MappingProfiles
{
    public class InterestProfile : Profile
    {
        public InterestProfile()
        {
            CreateMap<DataAccess.Models.InterestEntity, Models.Interest>()
                .ConvertUsing(source => new Models.Interest(source.Id, source.Name, (InterestType)Enum.Parse(typeof(InterestType), source.Type), source.IsCurrent, source.Detail));

            CreateMap<Models.Interest, DataAccess.Models.InterestEntity>()
                .ForMember(destination => destination.Type, opt => opt.MapFrom(source => source.Type.ToString()));
        }
    }
}