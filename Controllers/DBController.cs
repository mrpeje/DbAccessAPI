using Microsoft.AspNetCore.Mvc;
using OrdersManager.DB_Access;
using OrdersManager.DBcontext;

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
            return BadRequest();
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

        [HttpPost("EditOrder")]
        public IActionResult PostEditOrder()
        {
            return BadRequest();
        }

        [HttpPost("CreateOrder")]
        public IActionResult PostCreateOrder()
        {
            return BadRequest();
        }

        [HttpPost("DeleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            return BadRequest();
        }
    }
}