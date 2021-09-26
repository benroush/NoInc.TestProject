using AutoMapper;
using NoInc.BusinessLogic.Interfaces;
using NoInc.BusinessLogic.Models;
using NoInc.DataAccess.Interfaces;
using System.Threading.Tasks;

namespace NoInc.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUserDataAccess _userDataAccess;
        private readonly IMapper _mapper;

        public UserService(IUserDataAccess userDataAccess, IMapper mapper)
        {
            _userDataAccess = userDataAccess;
            _mapper = mapper;
        }

        public async Task<User> Get(string username, string password)
        {
            var userEntity = await _userDataAccess.Get(username, password);
            if (userEntity == null)
            {
                return null;
            }

            var mappedUser = _mapper.Map(userEntity, new User());
            return mappedUser;
        }
    }
}