using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoInc.BusinessLogic.Interfaces;
using NoInc.BusinessLogic.Models;
using NoInc.TestProject.Models.Requests;

namespace NoInc.TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterestController : ControllerBase
    {
        private readonly IInterestService _interestService;
        private readonly IMapper _mapper;

        public InterestController(IInterestService interestService, IMapper mapper)
        {
            _interestService = interestService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var interests = _interestService.Get();
            return Ok(interests);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var interest = _interestService.Get(id);
            if (interest == null)
            {
                return NotFound($"No Interest exists with an id of {id}");
            }

            return Ok(interest);
        }

        [HttpPost]
        public void Post(CreateInterestRequest request)
        {
            var interest = _mapper.Map(request, new Interest());
            _interestService.Save(interest);
        }

        [HttpPut("{id}")]
        public void Put(int id)
        {
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //TODO check if record exists, tell user no delete happened if it doesn't
            _interestService.Delete(id);
            return Ok($"Deleted Interest with id {id}");
        }
    }
}
