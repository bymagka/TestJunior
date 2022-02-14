

using BLL.Domain.BusinessObjects;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BLL.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISalesRepo _salesRepo;
        private readonly IBuyersRepo _buyersRepo;
        private readonly IProductsRepo _productsRepo;
        private readonly ISalesPointsRepo _salesPointRepo;
        private readonly ILogger<SaleService> _logger;

        public SaleService(ISalesRepo salesRepo, ISalesPointsRepo salesPointRepo, IBuyersRepo buyersRepo, IProductsRepo productsRepo, ILogger<SaleService> logger)
        {
            this._salesRepo = salesRepo;
            this._buyersRepo = buyersRepo;
            this._productsRepo = productsRepo;
            this._salesPointRepo = salesPointRepo;
            this._logger = logger;
        }

        public bool Add(BO_Sale businessObject)
        {
            var salesPoint = _salesPointRepo.GetOne(businessObject.SalesPointId);

            if (salesPoint.ProvidedProducts.Count < businessObject.SalesData.Count)
                return false;

            var query = businessObject.SalesData
                .Join(salesPoint.ProvidedProducts,
                      saleData => saleData.ProductId,
                      sp => sp.Product.Id,
                      (saleData, sp) => new { saleData, sp }
                );

            if (query.Count() != businessObject.SalesData.Count)
                return false;

            if (query.Where(x => x.saleData.ProductQuantity > x.sp.Quantity).Count() > 0)
                return false;

            //здесь по хорошему должна быть транзакция, но нет доступа к контексту бд (добавить контекст в базовый интерфейс сервисов?)
            var newSale = new Sale
            {
                Buyer = businessObject.BuyerId is null ? null : _buyersRepo.GetOne((int)businessObject.BuyerId),

                SalesPoint = _salesPointRepo.GetOne(businessObject.SalesPointId),

                SalesDate = ProcessDateFromString(businessObject.Date, businessObject.Time),

                SalesData = businessObject.SalesData.Select(sd => new SaleData
                {
                    Product = _productsRepo.GetOne(sd.ProductId),
                    Quantity = sd.ProductQuantity,
                }).ToList()

            };

            var resultSaleSaving = _salesRepo.Add(newSale);

            if (resultSaleSaving) businessObject.Id = newSale.Id;
            else return resultSaleSaving;

            foreach (var item in query)
            {
                item.sp.Quantity -= item.saleData.ProductQuantity;
            }

            resultSaleSaving = _salesPointRepo.Update(salesPoint);

            if (!resultSaleSaving)
                return resultSaleSaving;


            if (newSale.Buyer is { })
            {
                newSale.Buyer.SalesIds.Add(new SaleId { Value = newSale.Id });
                resultSaleSaving = _buyersRepo.Update(newSale.Buyer);
            }

            return resultSaleSaving;
        }

        public bool Delete(int id)
        {
            var deletedSale = _salesRepo.GetOne(id);

            if (deletedSale is null)
                return false;

            return _salesRepo.Delete(deletedSale);
        }

        public BO_Sale Get(int id)
        {
            var result = _salesRepo.GetOne(id);

            if (result is null) return null;
            else return result.To_BO();
        }

        public ICollection<BO_Sale> GetAll()
        {
            return _salesRepo.GetAll().To_BO();
        }

        public bool Update(BO_Sale businessObject)
        {
            var updatedSale = _salesRepo.GetOne(businessObject.Id);

            if (updatedSale is null)
                return false;

            updatedSale.Buyer = _buyersRepo.GetOne(businessObject.Id);
            updatedSale.SalesPoint = _salesPointRepo.GetOne(businessObject.SalesPointId);

            updatedSale.SalesData = businessObject.SalesData.Select(sd => new SaleData {
                Product = _productsRepo.GetOne(sd.ProductId),
                Quantity = sd.ProductQuantity,
            }).ToList();


            updatedSale.SalesDate = ProcessDateFromString(businessObject.Date, businessObject.Time);

            return _salesRepo.Update(updatedSale);
        }


        private DateTime ProcessDateFromString(string date, string time)
        {
            if (DateTime.TryParse($"{date} {time}", out DateTime result))
                return result;
            else
                return DateTime.Now;
        }
    }
}
