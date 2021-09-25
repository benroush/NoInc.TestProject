using NoInc.DataAccess.Models;
using System.Linq;

namespace NoInc.DataAccess.Interfaces
{
    public interface IInterestDataAccess
    {
        InterestEntity Get(int id);
        IQueryable<InterestEntity> GetAll();
        void Save(InterestEntity interest);
        void Delete(int id);
    }
}