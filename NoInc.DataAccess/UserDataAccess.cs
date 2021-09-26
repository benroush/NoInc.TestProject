using Microsoft.EntityFrameworkCore;
using NoInc.DataAccess.DatabaseContext;
using NoInc.DataAccess.Interfaces;
using NoInc.DataAccess.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NoInc.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly NoIncContext _dbContext;

        public UserDataAccess(NoIncContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserEntity> Get(string username, string password) => await _dbContext.Users.Where(user => user.UserName == username && user.Password == password).FirstOrDefaultAsync();
    }
}