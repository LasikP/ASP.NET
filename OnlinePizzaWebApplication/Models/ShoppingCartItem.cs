using System.ComponentModel;

namespace OnlinePizzaWebApplication.Models
{
	public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
		public Pizzas Pizza { get; set; }

		[DisplayName("Cena")]
		public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
