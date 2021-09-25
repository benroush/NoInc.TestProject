using AutoMapper;
using NoInc.BusinessLogic.Interfaces;
using NoInc.BusinessLogic.Models;
using NoInc.DataAccess.Interfaces;
using NoInc.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace NoInc.BusinessLogic
{
    public class SkillService : ISkillService
    {
        private readonly ISkillDataAccess _skillDataAccess;
        private readonly IMapper _mapper;

        public SkillService(ISkillDataAccess skillDataAccess, IMapper mapper)
        {
            _skillDataAccess = skillDataAccess;
            _mapper = mapper;
        }

        public Skill Get(int id)
        {
            var skillEntity = _skillDataAccess.Get(id);
            if (skillEntity == null)
            {
                return null;
            }

            var mappedSkill = _mapper.Map(skillEntity, new Skill());
            return mappedSkill;
        }

        public IEnumerable<Skill> Get()
        {
            var allSkillEntities = _skillDataAccess.Get().ToList();
            var mappedSkills = _mapper.Map(allSkillEntities, new List<Skill>());
            return mappedSkills;
        }

        public void Save(Skill skill)
        {
            var mappedSkillEntity = _mapper.Map(skill, new SkillEntity());
            _skillDataAccess.Save(mappedSkillEntity);
        }

        public void Delete(int id)
        {
            _skillDataAccess.Delete(id);
        }
    }
}