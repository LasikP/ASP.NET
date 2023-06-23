using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace OnlinePizzaWebApplication.Models
{
	public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
		[DisplayName("Liczba")]
		public int Amount { get; set; }
        [Precision(18, 2)]
		[DisplayName("Cena")]
		public decimal Price { get; set; }
        public virtual Pizzas Pizza { get; set; }
        public virtual Order Order { get; set; }
    }
}
