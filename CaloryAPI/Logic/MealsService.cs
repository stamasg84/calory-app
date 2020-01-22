using Core.Interfaces;
using Core.Model;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class MealsService : IMealsService
    {
        private readonly IRepository<Meal> repository;

        public MealsService(IRepository<Meal> repository)
        {
            this.repository = repository;
        }

        public void CreateMeals(IEnumerable<Meal> meals)
        {
            repository.Create(meals);
        }

        public List<Meal> GetMeals(DateTime? dateFilter = null)
        {
            if(dateFilter != null)
            {
                return repository.Get(m => m.TimeOfConsumption == dateFilter);
            }

            return repository.Get();
        }
    }
}
