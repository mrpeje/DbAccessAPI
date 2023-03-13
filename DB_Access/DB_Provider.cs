using OrdersManager.DBcontext;
using Microsoft.EntityFrameworkCore;

namespace OrdersManager.DB_Access
{
    public class DB_Provider : IDB_Provider
    {
        private readonly OrdersManagerContext _context;
        public DB_Provider(OrdersManagerContext context)
        {
            _context = context;
        }
        public void CreateOrder() 
        { 

        }
        public void UpdateOrder()
        {

        }
        public void DeleteOrder()
        {

        }
        public void DeleteOrderItem()
        {

        }

        public Order GetOrderById(int id)
        {
            return null;
        }
        public List<Order> GetOrdersByProvider(int providerId)
        {
            return new List<Order>();
        }
        public List<Order> GetAllOrders()
        {
            var orders = _context.Order.Include(e=>e.Provider).ToList();

            return orders;
        }
    }

}
