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
            var order = _dbProvider.GetOrderById(id);
            if(order == null)
                return BadRequest();
            return Ok(order);
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

            }
            return new List<Order>();
            
        }
        [HttpGet("provider/{id}")]

        public ActionResult<List<Order>> GetOrdersByProvider()
        {
            return BadRequest();
        }

        private IActionResult EditOrder(OrderWithItems dataModel)
        {
            return BadRequest();
        }
        private IActionResult CreateOrder(OrderWithItems dataModel)
        {
            return BadRequest();
        }

        [HttpPost("CreateEditOrder")]
        public IActionResult PostProcessOrder(OrderWithItems dataModel)
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

        [HttpDelete ("Order/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var result = _dbProvider.DeleteOrder(id);

            if (result == OperationStatus.Success)
                return Ok();
            else
                return BadRequest();
        }
    }
}