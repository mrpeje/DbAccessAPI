using OrdersManager.DBcontext;
using OrdersManager.Models;

namespace OrdersManager.DB_Access
{
    public interface IDB_Provider
    {
        public OperationStatus CreateOrder(OrderWithItems dataModel);
        public OperationStatus UpdateOrder(OrderWithItems dataModel);
        public OperationStatus DeleteOrder(int id);

        public OrderWithItems GetOrderById(int id);
        public List<Order> GetOrdersByProvider(int providerId);
        public List<Order> GetAllOrders();
    }
}
