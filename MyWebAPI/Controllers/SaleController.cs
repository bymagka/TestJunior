

using BLL.Domain.BusinessObjects;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/sales")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService salesService;
        private readonly ILogger<SaleController> logger;

        public SaleController(ISaleService salesService,ILogger<SaleController> logger)
        {
            this.salesService = salesService;
            this.logger = logger;
        }

        [HttpGet("")]
        public IActionResult GetAllSales()
        {
            logger.LogInformation("getting all sales");

            var salesPoints = salesService.GetAll();

            return Ok(salesPoints);
        }

        [HttpGet("{id}")]
        public IActionResult GetSale(int id)
        {
            logger.LogInformation("query for sales by id {0}", id.ToString());

            var sale = salesService.Get(id);

            if (sale is null)
            {
                logger.LogError("sale is not found by {0}", id.ToString());
                return NotFound(id);
            }
            else
            {
                logger.LogInformation("sale is found by {0}", id.ToString());
                return Ok(sale);
            }
                
        }



        [HttpPost]
        public IActionResult AddSale(BO_Sale sale)
        {
            logger.LogInformation("adding sale");

            bool succes = salesService.Add(sale);

            if (succes)
                logger.LogInformation("sale has been added. New id is {0}", sale.Id.ToString());
            else
                logger.LogError("sale hasn't been added");

            return succes ? Ok(sale) : NotFound(sale);
        }

        [HttpDelete]
        public IActionResult DeleteSale(int id)
        {
            logger.LogInformation("deleting sales point");

            bool succes = salesService.Delete(id);

            if (succes)
                logger.LogInformation("sale with id {0} has been deleted.", id.ToString());
            else
                logger.LogError("sale with id {0} hasn't been deleted", id.ToString());

            return succes ? Ok(id) : NotFound(id);
        }

        [HttpPost("update")]
        public IActionResult UpdateProduct(BO_Sale sale)
        {
            logger.LogInformation("adding sales point");

            bool succes = salesService.Update(sale);

            if (succes)
                logger.LogInformation("sales with id {0} has been updated.", sale.Id.ToString());
            else
                logger.LogError("sales with id {0} hasn't been added", sale.Id.ToString());

            return succes ? Ok(sale) : NotFound(sale);
        }
    }
}
