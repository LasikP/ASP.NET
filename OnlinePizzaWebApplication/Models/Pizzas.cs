using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlinePizzaWebApplication.Models
{
	public class Pizzas
    {
        public Pizzas()
        {
           
            Reviews = new HashSet<Reviews>();
        }

        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Pole Nazwa powinno zawierać tylko litery i cyfry.")]
        [DataType(DataType.Text)]
        [Required]
		[DisplayName("Nazwa")]
		public string Name { get; set; }

        [Range(0, 1000)]
        [DataType(DataType.Currency)]
        [Required]
        [Precision(18, 2)]
		[DisplayName("Cena")]
		public decimal Price { get; set; }

        [StringLength(255, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        [Required]
		[DisplayName("Opis")]
		public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
		[DisplayName("Pizza tygodnia")]
		public bool IsPizzaOfTheWeek { get; set; }

        [DisplayName("Wybierz kategorię")]
        public int CategoriesId { get; set; }
		[DisplayName("Kategoria")]
		public virtual Categories Category { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }

    }
}
