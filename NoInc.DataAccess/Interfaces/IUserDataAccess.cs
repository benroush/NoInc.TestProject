using NoInc.DataAccess.Models;
using System.Threading.Tasks;

namespace NoInc.DataAccess.Interfaces
{
    public interface IUserDataAccess
    {
        Task<UserEntity> Authenticate(string username, string password);
    }
}