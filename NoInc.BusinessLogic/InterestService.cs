using AutoMapper;
using NoInc.BusinessLogic.Interfaces;
using NoInc.BusinessLogic.Models;
using NoInc.DataAccess.Interfaces;
using NoInc.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace NoInc.BusinessLogic
{
    public class InterestService : IInterestService
    {
        private readonly IInterestDataAccess _interestDataAccess;
        private readonly IMapper _mapper;

        public InterestService(IInterestDataAccess interestDataAccess, IMapper mapper)
        {
            _interestDataAccess = interestDataAccess;
            _mapper = mapper;
        }

        public Interest Get(int id)
        {
            var interestEntity = _interestDataAccess.Get(id);
            var mappedInterest = _mapper.Map(interestEntity, new Interest());
            return mappedInterest;
        }

        public IEnumerable<Interest> Get()
        {
            var allInterestEntities = _interestDataAccess.Get().ToList();
            var mappedInterests = _mapper.Map(allInterestEntities, new List<Interest>());
            return mappedInterests;
        }

        public void Save(Interest interest)
        {
            var mappedInterestEntity = _mapper.Map(interest, new InterestEntity());
            _interestDataAccess.Save(mappedInterestEntity);
        }

        public void Delete(int id)
        {
            _interestDataAccess.Delete(id);
        }
    }
}