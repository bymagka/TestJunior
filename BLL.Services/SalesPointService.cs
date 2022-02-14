using BLL.Domain.BusinessObjects;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using DAL.Repositories.Interfaces;
using DAL.Entities;
using System.Linq;

namespace BLL.Services
{
    public class SalesPointService : ISalesPointService
    {
        private readonly ISalesPointsRepo _salesPointRepo;
        private readonly IProductsRepo _productsRepo;
        private readonly ILogger<SalesPointService> _logger;

        public SalesPointService(ISalesPointsRepo salesPointRepo, IProductsRepo productsRepo, ILogger<SalesPointService> logger)
        {
            this._salesPointRepo = salesPointRepo;
            this._productsRepo = productsRepo;
            this._logger = logger;
        }

        public bool Add(BO_SalesPoint businessObject)
        {
            var newSP = new SalesPoint
            {
                Id = businessObject.Id,
                Name = businessObject.Name,
                ProvidedProducts = businessObject.ProvidedProducts.Select(pp => new ProvidedProduct {
                    Product = _productsRepo.GetOne(pp.ProductId),
                    Quantity = pp.ProductQuantity
                }).ToList()
            };

            var result = _salesPointRepo.Add(newSP);

            if (result) businessObject.Id = newSP.Id;

            return result;
        }

        public bool Delete(int id)
        {
            var deletedSP = _salesPointRepo.GetOne(id);

            if (deletedSP is null)
                return false;

            return _salesPointRepo.Delete(deletedSP);
        }

        public BO_SalesPoint Get(int id)
        {
            var result = _salesPointRepo.GetOne(id);

            if (result is null) return null;
            else return result.To_BO();
        }

        public ICollection<BO_SalesPoint> GetAll()
        {
            return _salesPointRepo.GetAll().To_BO();
        }

        public bool Update(BO_SalesPoint businessObject)
        {
            var updatedSP = _salesPointRepo.GetOne(businessObject.Id);

            if (updatedSP is null)
                return false;

            updatedSP.Name = businessObject.Name;
            updatedSP.ProvidedProducts = businessObject.ProvidedProducts.Select(pp => new ProvidedProduct
            {
                Product = _productsRepo.GetOne(pp.ProductId),
                Quantity = pp.ProductQuantity
            }).ToList();

            return _salesPointRepo.Update(updatedSP);
        }
    }
}
