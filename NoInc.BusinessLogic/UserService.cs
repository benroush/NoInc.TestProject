using NoInc.BusinessLogic.Interfaces;
using NoInc.DataAccess.Interfaces;
using NoInc.DataAccess.Models;
using System.Threading.Tasks;

namespace NoInc.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUserDataAccess _userDataAccess;

        public UserService(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public async Task<UserEntity> Authenticate(string username, string password) => await _userDataAccess.Authenticate(username, password);
    }
}