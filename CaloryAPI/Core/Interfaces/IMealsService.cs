using Core.Model;
using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IMealsService
    {
        public void CreateMeals(IEnumerable<Meal> meals);

        public List<Meal> GetMeals(DateTime? dateFilter = null);
    }
}
