using OrdersManager.DBcontext;
using OrdersManager.Models;

namespace OrdersManager.DB_Access
{
    public interface IDB_Provider
    {
        public OperationStatus CreateOrder(EditCreateModel dataModel);
        public OperationStatus UpdateOrder(EditCreateModel dataModel);
        public OperationStatus DeleteOrder(int id);

        public Order GetOrderById(int id);
        public List<Order> GetOrdersByProvider(int providerId);
        public List<Order> GetAllOrders();
    }
}
