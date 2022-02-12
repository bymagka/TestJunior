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
            return products.Select(prod => new BO_Product
            {
                Id = prod.Id,
                Name = prod.Name,
                Price = prod.Price,
            }
            ).ToList();
        }

        #endregion
    
    
    }
}
