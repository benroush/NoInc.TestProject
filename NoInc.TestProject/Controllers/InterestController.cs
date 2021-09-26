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
            var mappedInterests = _mapper.Map(interests, new List<GetInterestResponse>());
            return Ok(mappedInterests);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var interest = _interestService.Get(id);
            if (interest == null)
            {
                return NotFound($"No Interest exists with an id of {id}");
            }

            var mappedInterest = _mapper.Map(interest, new GetInterestResponse());
            return Ok(mappedInterest);
        }

        [HttpPost]
        public void Post(CreateInterestRequest request)
        {
            var interest = _mapper.Map(request, new Interest());
            _interestService.Save(interest);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _interestService.Delete(id);
            return Ok($"Deleted Interest with id {id}");
        }
    }
}