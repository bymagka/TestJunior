

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    /// <summary>
    /// Данные о продаваемых товарах в акте продажи
    /// </summary>
    public class SaleData : BaseEntities.BaseEntity
    {
        /// <summary>
        /// Продаваемый товар
        /// </summary>
        [Required]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        /// <summary>
        /// Количество штук купленных товаров
        /// </summary>
        public int Quantity { get; set; }

        
    }
}
