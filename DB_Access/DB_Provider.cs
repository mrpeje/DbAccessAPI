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
        public OperationStatus CreateOrder(Order order) 
        {
            order.Provider = _context.Provider.FirstOrDefault(e=>e.Id == order.ProviderId);
            _context.Order.Add(order);
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
            var orders = _context.Order.Where(e=>e.ProviderId == providerId).ToList();
            return orders;
        }
        public List<OrderItem> GetItemsByOrderId(int orderId)
        {
            var orders = _context.OrderItem.Where(e => e.OrderId == orderId).ToList();
            return orders;
        }
        public List<Order> GetAllOrders()
        {
            var orders = _context.Order.Include(e=>e.Provider).ToList();

            return orders;
        }
        public List<Provider> GetAllProviders()
        {
            var providers = _context.Provider.ToList();
            return providers;
        }

        

        public OperationStatus UpdateOrder(Order order)
        {
            try
            {
                // Update order
                var dbOrder = _context.Entry(order);
                dbOrder.State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return OperationStatus.Error;
            }
            return OperationStatus.Success;
        }

        public OperationStatus CreateOrderItem(OrderItem item, int orderId)
        {
            try
            {
                var order = _context.Order.FirstOrDefault(e => e.Id == orderId);
                if (order != null)
                {
                    item.Order = order;
                    item.OrderId = order.Id;
                    _context.OrderItem.Add(item);
                    _context.SaveChanges();
                    return OperationStatus.Success;
                }
                else
                {
                    return OperationStatus.NotFound;
                }
            }
            catch(Exception ex)
            {
                return OperationStatus.Error;
            }
        }

        public OperationStatus UpdateOrderItem(OrderItem item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return OperationStatus.Error;
            }
            return OperationStatus.Success;

        }

        public OperationStatus DeleteOrderItem(int id)
        {           
            try
            {
                var item = _context.OrderItem.FirstOrDefault(e=>e.Id == id);
                if (item != null)
                {
                    _context.OrderItem.Remove(item);
                    _context.SaveChanges();
                    return OperationStatus.Success;
                }
                else
                {
                    return OperationStatus.NotFound;
                }
            }
            catch (Exception ex)
            {
                return OperationStatus.Error;
            }
            
        }
    }
    public enum OperationStatus
    {
        Success = 0,
        Error = 1,
        NotFound = 2
    }

}
