using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CaloryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealsController : ControllerBase
    {      
        public MealsController()
        {
            
        }

        [HttpGet]
        public IEnumerable<Meal> Get()
        {
            return new[] { new Meal() };
        }
    }
}
