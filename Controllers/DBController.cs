using Microsoft.AspNetCore.Mvc;
using OrdersManager.DB_Access;
using OrdersManager.DBcontext;
using OrdersManager.Models;

namespace DbAccessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderManager : ControllerBase
    {
        private readonly IDB_Provider _dbProvider;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public OrderManager(IDB_Provider dbProvider)
        {
            _dbProvider = dbProvider;
        }

        [HttpGet("Order/{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            try
            {
                var order = _dbProvider.GetOrderById(id);
                if (order == null)
                    return BadRequest();
                return Ok(order);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message + "method GetOrder by " + id);
                return BadRequest();
            }            
        }

        [HttpGet("")]
        public List<Order> GetAllOrders()
        {
            try
            {
                return _dbProvider.GetAllOrders();
            }
            catch(Exception e)
            {
                Logger.Error(e.Message + "method GetAllOrders");
                return new List<Order>();
            }                      
        }
        [HttpGet("Providers")]
        public List<Provider> GetAllProviders()
        {
            try
            {
                return _dbProvider.GetAllProviders();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message + "method GetAllProviders");
                return new List<Provider>();
            }
        }

        [HttpGet("Providers/provider/{id}")]
        public ActionResult<List<Order>> GetOrdersByProvider(int id)
        {
            try
            {
                var orders = _dbProvider.GetOrdersByProvider(id);
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest();
                Logger.Error(e.Message + " method GetOrdersByProvider id:" + id);
            }
        }

        [HttpDelete("Order/Item/{id}")]
        public IActionResult DeleteOrderItem(int id)
        {
            try
            {
                var result = _dbProvider.DeleteOrderItem(id);

                if (result == OperationStatus.Success)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message + " method DeleteOrderItem id:" + id);
                return BadRequest();
            }
        }
        [HttpDelete ("Order/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                var result = _dbProvider.DeleteOrder(id);

                if (result == OperationStatus.Success)
                    return Ok();
                else
                    return BadRequest();
            }
            catch(Exception e)
            {
                Logger.Error(e.Message + " method DeleteOrder id:"+id);
                return BadRequest();
            }

        }
        [HttpGet("Order/Items/{id}")]
        public List<OrderItem> GetItemsByOrderId(int id)
        {
            try
            {                
                return _dbProvider.GetItemsByOrderId(id);
            }
            catch(Exception e)
            {
                Logger.Error(e.Message + "method GetAllOrders");
                return new List<OrderItem>();
            }
        }
        [HttpPut("Order/Item")]
        public IActionResult UpdateOrderItem(OrderItem item)
        {
            try
            {
                var result = _dbProvider.UpdateOrderItem(item);

                if (result == OperationStatus.Success)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message + " method UpdateOrderItem id:" + item.Id);
                return BadRequest();
            }
        }
        [HttpPut("Order")]
        public IActionResult UpdateOrder(Order order)
        {
            try
            {
                var result = _dbProvider.UpdateOrder(order);

                if (result == OperationStatus.Success)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message + " method UpdateOrder id:" + order.Id);
                return BadRequest();
            }
        }
        [HttpPost("Order/Item/{orderId}")]
        public IActionResult CreateOrderItem(OrderItem item, int orderId)
        {
            try
            {
                var result = _dbProvider.CreateOrderItem(item, orderId);

                if (result == OperationStatus.Success)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message + " method UpdateOrderItem id:" + item.Id);
                return BadRequest();
            }
        }
    }
}