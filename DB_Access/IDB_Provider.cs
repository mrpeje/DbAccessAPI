using OrdersManager.DBcontext;

namespace OrdersManager.DB_Access
{
    public interface IDB_Provider
    {
        public void CreateOrder();
        public void UpdateOrder();
        public void DeleteOrder();
        public void DeleteOrderItem();
        public Order GetOrderById(int id);
        public List<Order> GetOrdersByProvider(int providerId);
        public List<Order> GetAllOrders();
    }
}
