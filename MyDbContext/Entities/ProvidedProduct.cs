using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    /// <summary>
    /// Доступные к продаже товары
    /// </summary>
    public class ProvidedProduct
    {

        /// <summary>
        /// Товар
        /// </summary>
        [Required]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        [Required]
        public int Quantity { get; set; }

    }
}
