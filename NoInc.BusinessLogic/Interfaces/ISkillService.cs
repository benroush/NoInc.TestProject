using NoInc.BusinessLogic.Models;
using System.Collections.Generic;

namespace NoInc.BusinessLogic.Interfaces
{
    public interface ISkillService
    {
        Skill Get(int id);
        IEnumerable<Skill> Get();
        void Save(Skill skill);
        void Delete(int id);
    }
}