using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Domain.BusinessObjects
{
    /// <summary>
    /// Бизнес модель доступных к продаже товаров
    /// </summary>
    public class BO_ProvidedProduct
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Количество товара
        /// </summary>
        public int ProductQuantity { get; set; }
    }
}
