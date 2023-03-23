using Microsoft.AspNetCore.Mvc;
using OrdersManager.DB_Access;
using OrdersManager.DBcontext;
using OrdersManager.Models;

namespace DbAccessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IDB_Provider _dbProvider;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public OrdersController(IDB_Provider dbProvider)
        {
            _dbProvider = dbProvider;
        }

        [HttpGet("{id}")]
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

        [HttpGet("provider/{id}")]
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

        [HttpPost("CreateEditOrder")]
        public IActionResult PostProcessOrder(OrderWithItems dataModel)
        {
            try
            {           
                var result = OperationStatus.Error;
                if (dataModel.Order.Id == 0)
                {
                    result = _dbProvider.CreateOrder(dataModel);
                }
                else
                {
                    result = _dbProvider.UpdateOrder(dataModel);
                }
                if (result == OperationStatus.Success)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message + " method PostProcessOrder");
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
    }
}