using Microsoft.AspNetCore.Mvc;
using NoInc.BusinessLogic.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoInc.TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterestsController : ControllerBase
    {
        private readonly IInterestService _interestService;

        public InterestsController(IInterestService interestService)
        {
            _interestService = interestService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var interests = _interestService.Get();
            return Ok(interests);
        }

        // GET api/<InterestsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var interest = _interestService.Get(id);
            return Ok(interest);
        }

        // POST api/<InterestsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InterestsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InterestsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //TODO check if record exists, tell user no delete happened if it doesn't
            _interestService.Delete(id);
            return Ok($"Deleted Interest with ID {id}");
        }
    }
}
