using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JotFormAuthenticator.Models;
using JotFormAuthenticator.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FormAuthenticator.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        //private readonly IFormRepository _repository;

        //public SampleDataController(IFormRepository Repository)
        //{
        //    _repository = Repository;
        //}

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //[HttpGet("[action]")]
        //public List<FormModel> Forms()
        //{
        //    return _repository.GetForms();
        //}

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get {
                    return 32 + (int) (TemperatureC / 0.5556);
                }
            }
        }
    }
}
