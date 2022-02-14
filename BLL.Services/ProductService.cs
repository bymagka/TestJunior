using BLL.Domain.BusinessObjects;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using DAL.Repositories.Interfaces;


namespace BLL.Services
{
    /// <summary>
    /// Бизнес логика по товарам
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductsRepo _productsRepo;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductsRepo productsRepo,ILogger<ProductService> logger)
        {
            this._productsRepo = productsRepo;
            this._logger = logger;
        }

        public bool Add(BO_Product businessObject)
        {
            var newProduct = businessObject.To_DAL();

            var result = _productsRepo.Add(newProduct);

            if(result) businessObject.Id = newProduct.Id;

            return result;
        }

        public bool Delete(int id)
        {
            var deletedProduct = _productsRepo.GetOne(id);

            if (deletedProduct is null)
                return false;

            return _productsRepo.Delete(deletedProduct);
        }

        public BO_Product Get(int id)
        {
            var result = _productsRepo.GetOne(id);

            if (result is null) return null;
            else return result.To_BO();
            
        }

        public ICollection<BO_Product> GetAll()
        {
            return _productsRepo.GetAll().To_BO();
        }

        public bool Update(BO_Product businessObject)
        {
            var updatedProduct = _productsRepo.GetOne(businessObject.Id);

            if (updatedProduct is null)
                return false;

            updatedProduct.Name = businessObject.Name;
            updatedProduct.Price = businessObject.Price;

            return _productsRepo.Update(updatedProduct);
        }
    }
}
