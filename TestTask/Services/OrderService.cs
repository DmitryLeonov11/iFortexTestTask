using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _db;

        public OrderService(ApplicationDbContext db) {
            _db = db;
        }
        public async Task<Order> GetOrder()
        {
            return _db.Orders.OrderByDescending(o => o.Quantity * o.Price).FirstOrDefault();
        }

        public async Task<List<Order>> GetOrders()
        {
            return _db.Orders.Where(o => o.Quantity > 10).ToList();
        }
    }
}
