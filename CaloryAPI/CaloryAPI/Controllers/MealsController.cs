using System;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Model;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var meal = mealsService.Get(id);

            if(meal == null)
            {
                return NotFound();
            }

            return Ok(meal);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(Meal meal)
        {
            //we'll go with automatic modelstate validation          

            mealsService.CreateMeals(new[] { meal });

            return CreatedAtAction(nameof(GetById), new { id = meal.Id }, meal);
        }
    }
}
