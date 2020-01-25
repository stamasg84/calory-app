using Core.Interfaces;
using Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace CaloryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AggregatorController : ControllerBase
    {
        private readonly IMealsService mealsService;

        public AggregatorController(IMealsService mealsService)
        {
            this.mealsService = mealsService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]string resource, [FromQuery]string field, [FromQuery] string filter)
        {
            if(string.IsNullOrEmpty(resource) || string.IsNullOrEmpty(field))
            {
                return BadRequest($"Both {nameof(resource)} and {nameof(field)} has to be specified in the query string.");
            }

            var aggregatorService = GetAggregatorServiceForResource(resource);

            if(aggregatorService == null)
            {
                return BadRequest($"Unknown resource {resource}");
            }

            if (!aggregatorService.IsValidFieldName(field))
            {
                return BadRequest($"Invalid field name {field}");
            }

            if (!aggregatorService.IsValidFilter(filter))
            {
                return BadRequest($"Invalid filter {filter}");
            }

            return Ok(aggregatorService.AggregateValues(field, filter));
        }

        private IAggregatorService GetAggregatorServiceForResource(string resource)
        {
            if(resource.ToLower() == nameof(Meal).ToLower())
            {
                return mealsService;
            }

            return null;
        } 
    }
}
