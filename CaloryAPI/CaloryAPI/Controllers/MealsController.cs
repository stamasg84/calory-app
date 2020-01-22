using System;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace CaloryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealsController : ControllerBase
    {
        private readonly IMealsService mealsService;

        public MealsController(IMealsService mealsService)
        {
            this.mealsService = mealsService;
        }

        [HttpGet]
        public IEnumerable<Meal> Get([FromQuery]DateTime? date)
        {
            return mealsService.GetMeals(date);
        }

        [HttpPost]
        public IActionResult Post(Meal meal)
        {
            //we'll go with automatic modelstate validation          

            mealsService.CreateMeals(new[] { meal });

            return Ok();
        }
    }
}
