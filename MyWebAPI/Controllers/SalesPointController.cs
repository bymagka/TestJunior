using BLL.Domain.BusinessObjects;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/salesPoints")]
    public class SalesPointController : ControllerBase
    {
        private readonly ISalesPointService spService;
        private readonly ILogger<SalesPointController> logger;

        public SalesPointController(ISalesPointService spService, ILogger<SalesPointController> logger)
        {
            this.spService = spService;
            this.logger = logger;
        }

        [HttpGet("")]
        public IActionResult GetAllSalesPoints()
        {
            logger.LogInformation("getting all sales points");

            var salesPoints = spService.GetAll();

            return Ok(salesPoints);
        }

        [HttpGet("{id}")]
        public IActionResult GetSalesPoint(int id)
        {
            logger.LogInformation("query for sales point by id {0}", id.ToString());

            var salesPoint = spService.Get(id);

            if (salesPoint is null)
                logger.LogError("sales point is not found by {0}", id.ToString());
            else
                logger.LogInformation("sales point is found by {0}", id.ToString());

            return salesPoint is null ? NotFound() : Ok(salesPoint);
        }



        [HttpPost]
        public IActionResult AddSalesPoint(BO_SalesPoint salesPoint)
        {
            logger.LogInformation("adding sales point");

            bool succes = spService.Add(salesPoint);

            if (succes)
                logger.LogError("sales point has been added. New id is {0}", salesPoint.Id.ToString());
            else
                logger.LogInformation("sales point hasn't been added");

            return succes ? Ok(salesPoint) : NotFound(salesPoint);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            logger.LogInformation("deleting sales point");

            bool succes = spService.Delete(id);

            if (succes)
                logger.LogError("sales point with id {0} has been deleted.", id.ToString());
            else
                logger.LogInformation("sales point with id {0} hasn't been deleted", id.ToString());

            return succes ? Ok(id) : NotFound(id);
        }

        [HttpPost("update")]
        public IActionResult UpdateProduct(BO_SalesPoint salesPoint)
        {
            logger.LogInformation("adding sales point");

            bool succes = spService.Update(salesPoint);

            if (succes)
                logger.LogError("sales point  with id {0} has been updated.", salesPoint.Id.ToString());
            else
                logger.LogInformation("sales point with id {0} hasn't been added", salesPoint.Id.ToString());

            return succes ? Ok(salesPoint) : NotFound(salesPoint);
        }
    }
}
