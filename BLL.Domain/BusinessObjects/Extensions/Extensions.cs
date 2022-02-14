using DAL.Entities;
using System.Collections.Generic;
using System.Linq;



namespace BLL.Domain.BusinessObjects
{
    public static class Extensions
    {

        #region Products
       
        public static BO_Product To_BO(this Product product)
        {
            return new BO_Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };
        }

        public static Product To_DAL(this BO_Product product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };
        }

        public static ICollection<BO_Product> To_BO(this ICollection<Product> products)
        {
            return products.Select(prod => prod.To_BO()).ToList();
        }

        #endregion

        #region SalesPoints
        public static BO_SalesPoint To_BO(this SalesPoint sp)
        {
            return new BO_SalesPoint
            {
                Id = sp.Id,
                Name = sp.Name,
                ProvidedProducts = sp.ProvidedProducts.Select((x) =>
                {
                    return new BO_ProvidedProduct { ProductId = x.Product.Id, ProductQuantity = x.Quantity };
                })
                .ToList()
            };
        }


        public static ICollection<BO_SalesPoint> To_BO(this ICollection<SalesPoint> salesPoints)
        {
            return salesPoints.Select(sp => sp.To_BO()).ToList();
        }


        #endregion

        #region Buyers
        public static BO_Buyer To_BO(this Buyer buyer)
        {
            return new BO_Buyer
            {
                Id = buyer.Id,
                Name = buyer.Name,
                SalesIds = buyer.SalesIds.Select(si=> new BO_SaleId { Value = si.Value}).ToList()
            };
        }


        public static ICollection<BO_Buyer> To_BO(this ICollection<Buyer> salesPoints)
        {
            return salesPoints.Select(b => b.To_BO()).ToList();
        }

        #endregion

        #region Sales
        public static BO_Sale To_BO(this Sale sale)
        {
            return new BO_Sale
            {
                Id = sale.Id,
                BuyerId = sale.Buyer?.Id,
                SalesPointId = sale.SalesPoint.Id,
                SalesData = sale.SalesData.Select(s=> new BO_SaleData
                {
                    ProductId = s.Product.Id,
                    ProductQuantity = s.Quantity,
                    ProductIdAmount = s.Product.Price * s.Quantity,
                }).ToList(),

                Date = sale.SalesDate.ToShortDateString(),
                Time = sale.SalesDate.ToShortTimeString(),
            };
        }


        public static ICollection<BO_Sale> To_BO(this ICollection<Sale> sales)
        {
            return sales.Select(s => s.To_BO()).ToList();
        }

        #endregion
    }
}
