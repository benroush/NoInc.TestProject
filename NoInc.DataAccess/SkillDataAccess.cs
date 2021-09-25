using Microsoft.EntityFrameworkCore;
using NoInc.DataAccess.DatabaseContext;
using NoInc.DataAccess.Interfaces;
using NoInc.DataAccess.Models;
using System;
using System.Linq;

namespace NoInc.DataAccess
{
    public class SkillDataAccess : ISkillDataAccess
    {
        private readonly NoIncContext _dbContext;

        public SkillDataAccess(NoIncContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SkillEntity Get(int id) => _dbContext.Skills.FirstOrDefault(skill => skill.Id == id);

        public IQueryable<SkillEntity> Get() => _dbContext.Skills;

        public void Save(SkillEntity skill)
        {
            using var transaction = _dbContext.Database.BeginTransaction();

            try
            {
                _dbContext.Skills.Add(skill);
                _dbContext.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                // log reason for failure and inform user.
            }
        }

        public void Delete(int id)
        {
            using var transaction = _dbContext.Database.BeginTransaction();

            try
            {
                var recordToDelete = new SkillEntity() { Id = id };
                _dbContext.Entry(recordToDelete).State = EntityState.Deleted;
                _dbContext.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                // log reason for failure and inform user.
            }
        }
    }
}