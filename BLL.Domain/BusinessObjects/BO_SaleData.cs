using System.Collections.Generic;


namespace BLL.Domain.BusinessObjects
{
    /// <summary>
    /// Бизнес модель продаваемых товаров
    /// </summary>
    public class BO_SaleData
    {
        /// <summary>
        /// Идентификатор проданного товара
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Количество продаваемого товара
        /// </summary>
        public int ProductQuantity { get; set; }
        
        /// <summary>
        /// Стоимость продаваемого товара
        /// </summary>
        public decimal ProductIdAmount { get; set; }
    }
}
