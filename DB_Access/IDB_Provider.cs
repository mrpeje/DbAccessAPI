using OrdersManager.Models;

namespace OrdersManager.DB_Access
{
    public interface IDB_Provider
    {
        public void CreateOrder();
        public void UpdateOrder();
        public void DeleteOrder();
        public void DeleteOrderItem();
        public OrderModel GetOrderById(int id);
        public List<OrderModel> GetOrdersByProvider(int providerId);
        public List<OrderModel> GetAllOrders();
    }
}
