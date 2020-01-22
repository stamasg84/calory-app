using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class Meal
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int? Calories { get; set; }

        [Required]
        public DateTime? TimeOfConsumption { get; set; }
    }
}
