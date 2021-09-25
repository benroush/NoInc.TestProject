using NoInc.BusinessLogic.Models;
using System.Collections.Generic;

namespace NoInc.BusinessLogic.Interfaces
{
    public interface IInterestService
    {
        Interest Get(int id);
        IEnumerable<Interest> Get();
        void Save(Interest interest);
        void Delete(int id);
    }
}