﻿using BLL.Domain.BusinessObjects;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyWebAPI.Controllers
{   
    [ApiController]
    [Route("api/buyers")]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerSerice buyerService;
        private readonly ILogger<BuyerController> logger;

        public BuyerController(IBuyerSerice buyerService, ILogger<BuyerController> logger)
        {
            this.buyerService = buyerService;
            this.logger = logger;
        }

        [HttpGet("")]
        public IActionResult GetAllBuyers()
        {
            logger.LogInformation("getting all buyers");

            var products = buyerService.GetAll();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetBuyer(int id)
        {
            logger.LogInformation("query for buyer by id {0}", id.ToString());

            var buyer = buyerService.Get(id);

            if (buyer is null)
                logger.LogError("buyer is not found by {0}", id.ToString());
            else
                logger.LogInformation("buyer is found by {0}", id.ToString());

            return buyer is null ? NotFound() : Ok(buyer);
        }



        [HttpPost]
        public IActionResult AddBuyer(BO_Buyer buyer)
        {
            logger.LogInformation("adding buyer");

            bool succes = buyerService.Add(buyer);

            if (succes)
                logger.LogError("buyer has been added. New id is {0}", buyer.Id.ToString());
            else
                logger.LogInformation("buyer hasn't been added");

            return succes ? Ok(buyer) : NotFound(buyer);
        }

        [HttpDelete]
        public IActionResult DeleteBuyer(int id)
        {
            logger.LogInformation("deleting buyer");

            bool succes = buyerService.Delete(id);

            if (succes)
                logger.LogError("buyer with id {0} has been deleted.", id.ToString());
            else
                logger.LogInformation("buyer with id {0} hasn't been deleted", id.ToString());

            return succes ? Ok(id) : NotFound(id);
        }

        [HttpPost("update")]
        public IActionResult UpdateBuyer(BO_Buyer buyer)
        {
            logger.LogInformation("adding buyer");

            bool succes = buyerService.Update(buyer);


            if (succes)
                logger.LogError("buyer with id {0} has been updated.", buyer.Id.ToString());
            else
                logger.LogInformation("buyer with id {0} hasn't been added", buyer.Id.ToString());

            return succes ? Ok(buyer) : NotFound(buyer);
        }
    }
}
