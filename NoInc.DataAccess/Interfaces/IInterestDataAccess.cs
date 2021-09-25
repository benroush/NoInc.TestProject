using NoInc.DataAccess.Models;
using System.Linq;

namespace NoInc.DataAccess.Interfaces
{
    public interface IInterestDataAccess
    {
        InterestEntity Get(int id);
        IQueryable<InterestEntity> Get();
        void Save(InterestEntity interest);
        void Delete(int id);
    }
}