using OrdersManager.DBcontext;
using OrdersManager.Models;

namespace OrdersManager.DB_Access
{
    public interface IDB_Provider
    {
        public OperationStatus CreateOrder(Order order);
        public OperationStatus CreateOrderItem(OrderItem item, int orderId);
        public OperationStatus UpdateOrder(Order order);
        public OperationStatus UpdateOrderItem(OrderItem item);
        public OperationStatus DeleteOrder(int id);
        public OperationStatus DeleteOrderItem(int id);

        public List<OrderItem> GetItemsByOrderId(int orderId);
        public OrderWithItems GetOrderById(int id);
        public List<Order> GetOrdersByProvider(int providerId);
        public List<Order> GetAllOrders();
        public List<Provider> GetAllProviders();
    }
}
