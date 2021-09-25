using Microsoft.EntityFrameworkCore;
using NoInc.DataAccess.DatabaseContext;
using NoInc.DataAccess.Interfaces;
using NoInc.DataAccess.Models;
using System;
using System.Linq;

namespace NoInc.DataAccess
{
    public class InterestDataAccess : IInterestDataAccess
    {
        private readonly NoIncContext _dbContext;

        public InterestDataAccess(NoIncContext dbContext)
        {
            _dbContext = dbContext;
        }

        public InterestEntity Get(int id) => _dbContext.Interests.First(interest => interest.Id == id);

        public IQueryable<InterestEntity> Get() => _dbContext.Interests;

        public void Save(InterestEntity interest)
        {
            using var transaction = _dbContext.Database.BeginTransaction();

            try
            {
                _dbContext.Interests.Add(interest);
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
                var recordToDelete = new InterestEntity() { Id = id };
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