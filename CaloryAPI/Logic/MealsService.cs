using Core.Interfaces;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;

namespace Logic
{
    public class MealsService : IMealsService
    {
        private readonly IRepository<Meal> repository;

        public MealsService(IRepository<Meal> repository)
        {
            this.repository = repository;
        }

        public int AggregateValues(string fieldName, string filter = null)
        {
            if (!IsValidFieldName(fieldName) || !IsValidFilter(filter))
            {
                throw new InvalidOperationException("Invalid field name or filter specified.");
            }
            
            DateTime? dateFilter = null;

            if(filter != null)
            {
                dateFilter = DateTime.Parse(filter, CultureInfo.InvariantCulture);
            }

            if (dateFilter != null)
            {
                var filterExpression = GetDateFilterExpression(dateFilter.Value);
                return repository.Sum(m => m.Calories.Value, filterExpression);
            }

            return repository.Sum(m => m.Calories.Value);
        }

        public void CreateMeals(IEnumerable<Meal> meals)
        {
            repository.Create(meals);
        }

        public List<Meal> GetMeals(DateTime? dateFilter = null)
        {
            if(dateFilter != null)
            {
                var filterExpression = GetDateFilterExpression(dateFilter.Value);
                return repository.Get(filterExpression);
            }

            return repository.Get();
        }

        public bool IsValidFieldName(string fieldName)
        {
            return fieldName?.ToLower() == nameof(Meal.Calories).ToLower();            
        }

        public bool IsValidFilter(string filter)
        {
            DateTime dateFilter;
            return filter == null || DateTime.TryParse(filter, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateFilter);
        }

        private Expression<Func<Meal, bool>> GetDateFilterExpression(DateTime dateTime)
        {
            return m => m.TimeOfConsumption.HasValue && m.TimeOfConsumption.Value.Date == dateTime.Date;
        }
    }
}
