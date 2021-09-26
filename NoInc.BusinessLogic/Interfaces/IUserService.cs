using NoInc.BusinessLogic.Models;
using System.Threading.Tasks;

namespace NoInc.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<User> Get(string username, string password);
    }
}