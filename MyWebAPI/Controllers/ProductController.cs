using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services;
using BLL.Domain.BusinessObjects;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductController> logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            this.productService = productService;
            this.logger = logger;
        }

        [HttpGet("")]
        public IActionResult GetAllProducts()
        {
            logger.LogInformation("getting all products");

            var products = productService.GetAll();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            logger.LogInformation("query for product by id {0}", id.ToString());

            var product = productService.Get(id);

            if (product is null)
                logger.LogError("product is not found by {0}", id.ToString());
            else
                logger.LogInformation("product is found by {0}", id.ToString());

            return product is null ? NotFound() : Ok(product);
        }



        [HttpPost]
        public IActionResult AddProduct(BO_Product product)
        {
            logger.LogInformation("adding product");

            bool succes = productService.Add(product);

            if (succes)
                logger.LogError("product has been added. New id is {0}", product.Id.ToString());
            else
                logger.LogInformation("product hasn't been added");

            return succes ? Ok(product) : NotFound(product);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            logger.LogInformation("deleting product");

            bool succes = productService.Delete(id);

            if (succes)
                logger.LogError("product with id {0} has been deleted.", id.ToString());
            else
                logger.LogInformation("product with id {0} hasn't been deleted", id.ToString());

            return succes ? Ok(id) : NotFound(id);
        }

        [HttpPost("update")]
        public IActionResult UpdateProduct(BO_Product product)
        {
            logger.LogInformation("adding product");

            bool succes = productService.Update(product);


            if (succes)
                logger.LogError("product with id {0} has been updated.",product.Id.ToString());
            else
                logger.LogInformation("product with id {0} hasn't been added", product.Id.ToString());

            return succes ? Ok(product) : NotFound(product);
        }
    }
}
