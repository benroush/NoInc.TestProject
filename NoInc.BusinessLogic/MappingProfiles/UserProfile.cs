using AutoMapper;

namespace NoInc.BusinessLogic.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<DataAccess.Models.UserEntity, Models.User>(); ;
        }
    }
}