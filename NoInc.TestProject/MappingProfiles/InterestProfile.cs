using AutoMapper;
using NoInc.TestProject.Models.Requests;

namespace NoInc.TestProject.MappingProfiles
{
    public class InterestProfile : Profile
    {
        public InterestProfile()
        {
            CreateMap<CreateInterestRequest, BusinessLogic.Models.Interest>()
                .ConvertUsing(source => new BusinessLogic.Models.Interest(source.Name, source.Type, source.IsCurrent, source.Detail));
        }
    }
}