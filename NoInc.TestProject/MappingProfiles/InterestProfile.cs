using AutoMapper;
using NoInc.TestProject.Models.Requests;
using NoInc.TestProject.Models.Responses;
using System;

namespace NoInc.TestProject.MappingProfiles
{
    public class InterestProfile : Profile
    {
        public InterestProfile()
        {
            CreateMap<BusinessLogic.Models.Interest, GetInterestResponse>();

            CreateMap<CreateInterestRequest, BusinessLogic.Models.Interest>()
                .ConvertUsing(source => new BusinessLogic.Models.Interest(source.Name, (Enums.InterestType)Enum.Parse(typeof(Enums.InterestType), source.Type), source.IsCurrent, source.Detail));
        }
    }
}