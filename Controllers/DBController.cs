using Microsoft.AspNetCore.Mvc;
using OrdersManager.DB_Access;
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
        public ActionResult<OrderModel> GetOrder(int id)
        {
            return BadRequest();
        }

        [HttpGet("")]
        public ActionResult<List<OrderModel>> GetAllOrders()
        {
            return BadRequest();
        }
        [HttpGet("provider/{id}")]

        public ActionResult<List<OrderModel>> GetOrdersByProvider()
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