using OrdersManager.DBcontext;
using OrdersManager.Models;

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

        public OrderModel GetOrderById(int id)
        {
            return null;
        }
        public List<OrderModel> GetOrdersByProvider(int providerId)
        {
            return new List<OrderModel>();
        }
        public List<OrderModel> GetAllOrders()
        {
            return new List<OrderModel>();
        }
    }

}
