using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyForm.Core.Extensions;
using EasyForm.Core.Models.Definitions;
using EasyForm.Core.Models.Definitions.Base;
using EasyForm.Core.Models.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var fieldDefinition = new TextboxFieldDefinition("test", "test");
            fieldDefinition.FieldName = "test";

            var filter = QueryBuilders.Contains(fieldDefinition, "test");
            var sort = QueryBuilders.SortBy(fieldDefinition, SortDirection.Desc);

            var searchCriteria = new SearchCriteria(1, 10, filter, sort);

            var rng = new Random();
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
