using NoInc.DataAccess.Models;
using System.Linq;

namespace NoInc.DataAccess.Interfaces
{
    public interface ISkillDataAccess
    {
        SkillEntity Get(int id);
        IQueryable<SkillEntity> Get();
        void Save(SkillEntity skill);
        void Delete(int id);
    }
}