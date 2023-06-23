using OnlinePizzaWebApplication.Models;
using System.Threading.Tasks;

namespace OnlinePizzaWebApplication.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);

    }
}
