using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlinePizzaWebApplication.Models
{
	public class Reviews
    {
        public int Id { get; set; }
		[Required(ErrorMessage = "Pole Nazwa nie może być puste")]
		[StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Pole Nazwa powinno zawierać tylko litery i cyfry.")]
        [DataType(DataType.Text)]
        [DisplayName("Nazwa")]
        public string Title { get; set; }
		[Required(ErrorMessage = "Pole Opis nie może być puste")]
		[StringLength(500, MinimumLength = 2)]
		[DataType(DataType.MultilineText)]
        [DisplayName("Opis")]
		public string Description { get; set; }
        [Range(1, 5)]
        [DisplayName("Ocena")]
		
		public int Grade { get; set; }
        [DisplayName("Data")]
        public DateTime Date { get; set; }

        [DisplayName("Wybierz Pizze")]
        public int PizzaId { get; set; }

        public virtual Pizzas Pizza { get; set; }

        public string UserId { get; set; }

        public IdentityUser User { get; set; }

    }
}