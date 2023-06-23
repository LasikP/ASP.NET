using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlinePizzaWebApplication.Models
{
    public class Categories
    {
        public Categories()
        {
            Pizzas = new HashSet<Pizzas>();
        }

        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Pole Nazwa powinno zawierać tylko litery i cyfry.")]
        [DataType(DataType.Text)]
		[Required(ErrorMessage = "Pole Nazwa nie może być puste")]
		[DisplayName("Nazwa")]
        public string Name { get; set; }
		[StringLength(255, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        [DisplayName("Opis")]
        public string Description { get; set; }

        public virtual ICollection<Pizzas> Pizzas { get; set; }

    }
}