using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoInc.BusinessLogic.Interfaces;
using NoInc.BusinessLogic.Models;
using NoInc.TestProject.Models.Requests;
using NoInc.TestProject.Models.Responses;
using System.Collections.Generic;

namespace NoInc.TestProject.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public SkillController(ISkillService skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var skills = _skillService.Get();
            var mappedSkills = _mapper.Map(skills, new List<GetSkillResponse>());
            return Ok(mappedSkills);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var skill = _skillService.Get(id);
            if (skill == null)
            {
                return NotFound($"No Skill exists with an id of {id}");
            }

            var mappedSkill = _mapper.Map(skill, new GetSkillResponse());
            return Ok(mappedSkill);
        }

        [HttpPost]
        public void Post(CreateSkillRequest request)
        {
            var skill = _mapper.Map(request, new Skill());
            _skillService.Save(skill);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //TODO check if record exists, tell user no delete happened if it doesn't
            _skillService.Delete(id);
            return Ok($"Deleted Skill with id {id}");
        }
    }
}