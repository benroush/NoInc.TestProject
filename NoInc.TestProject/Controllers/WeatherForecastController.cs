using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoInc.BusinessLogic.Interfaces;
using NoInc.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoInc.TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IInterestService _interestService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IInterestService interestService)
        {
            _logger = logger;
            _interestService = interestService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            var car = new Interest("Soccer", Enums.InterestType.Sport, true, "Soccer is a Sport and Sports are cool");
            _interestService.Save(car);
            var lar = _interestService.GetAll();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
