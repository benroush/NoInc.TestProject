using NoInc.DataAccess.Models;
using System.Threading.Tasks;

namespace NoInc.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity> Authenticate(string username, string password);
    }
}