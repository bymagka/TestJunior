using BLL.Domain.BusinessObjects;
using System;
using BLL.Services;
using System.Linq;

namespace SalesAPI.Services
{
    public class CreateSaleService : ICreateSaleService
    {
        private readonly IBuyerService buyerService;
        private readonly ISalesPointService salesPointService;
        private readonly ISaleService saleService;

        public CreateSaleService(IBuyerService buyerService, ISalesPointService salesPointService, ISaleService saleService)
        {
            this.buyerService = buyerService;
            this.salesPointService = salesPointService;
            this.saleService = saleService;
        }

        public bool Add(BO_Sale sale)
        {
            var salesPoint = salesPointService.Get(sale.SalesPointId);

            if (salesPoint.ProvidedProducts.Count < sale.SalesData.Count)
                return false;

            var query = sale.SalesData
               .Join(salesPoint.ProvidedProducts,
                     saleData => saleData.ProductId,
                     sp => sp.ProductId,
                     (saleData, sp) => new { saleData, sp }
               );

            if (query.Count() != sale.SalesData.Count)
                return false;

            if (query.Where(x => x.saleData.ProductQuantity > x.sp.ProductQuantity).Count() > 0)
                return false;

            var result = saleService.Add(sale);

            foreach (var item in query)
            {
                item.sp.ProductQuantity -= item.saleData.ProductQuantity;
            }

            result = salesPointService.Update(salesPoint);

            if (!result)
                return false;

            if (sale.BuyerId is null)
                return true;

            var buyer = buyerService.Get((int)sale.BuyerId);

            buyer.SalesIds.Add(new BO_SaleId { Value = sale.Id});

            return result;
        }
    }
}
