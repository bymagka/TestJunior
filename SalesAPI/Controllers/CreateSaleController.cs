using BLL.Domain.BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesAPI.Services;

namespace SalesAPI.Controllers
{
    [ApiController]
    [Route("api/make_sale")]
    public class CreateSaleController : ControllerBase
    {
        private readonly ICreateSaleService createService;
        private readonly ILogger<CreateSaleController> logger;

        public CreateSaleController(ICreateSaleService createService,ILogger<CreateSaleController> logger)
        {
            this.createService = createService;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult AddSale(BO_Sale sale)
        {
            bool success = createService.Add(sale);

            return success ? Ok(sale) : NotFound(sale);
        }
    }
}
