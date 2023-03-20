using OrdersManager.DBcontext;
using Microsoft.EntityFrameworkCore;
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
        public OperationStatus CreateOrder(OrderWithItems dataModel) 
        {
            var newOrder = new Order
            {
                Number = dataModel.Order.Number,
                Date = dataModel.Order.Date,
                ProviderId = dataModel.Order.ProviderId
            };
            dataModel.Order.Provider = _context.Provider.FirstOrDefault(e=>e.Id == dataModel.Order.ProviderId);
            _context.Order.Add(dataModel.Order);
            

            if (dataModel.OrderItems != null)
            {
                foreach (var item in dataModel.OrderItems)
                {
                    item.Order = dataModel.Order;
                    item.Id = dataModel.Order.Id;
                    _context.OrderItem.Add(item);
                }
            }
            try
            {
               _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return OperationStatus.Error;
            }
            return OperationStatus.Success;
        }
        public OperationStatus UpdateOrder(OrderWithItems dataModel)
        {
            return OperationStatus.Error;
        }
        
        public OperationStatus DeleteOrder(int id)
        {
            try
            {
                var orderItems = _context.OrderItem.Where(e => e.OrderId == id).ToList();
                foreach (var item in orderItems)
                {
                    _context.OrderItem.Remove(item);
                }
                var order = _context.Order.FirstOrDefault(e => e.Id == id);
                _context.Order.Remove(order);
                _context.SaveChanges();

                return OperationStatus.Success;
            }
            catch(Exception ex)
            {

            }
            return OperationStatus.Error;
        }


        public OrderWithItems GetOrderById(int id)
        {
            if (id == 0)
                return null;
            
            var order = _context.Order.FirstOrDefault(e => e.Id == id);
            var orderItems = _context.OrderItem.Where(e=>e.OrderId == id).ToList();
            var returnResult = new OrderWithItems(order, orderItems);

            return returnResult;
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
    public enum OperationStatus
    {
        Success = 0,
        Error = 1
    }

}
