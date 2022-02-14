using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    /// <summary>
    /// Доступные к продаже товары
    /// </summary>
    public class ProvidedProduct : BaseEntities.BaseEntity
    {

        /// <summary>
        /// Товар
        /// </summary>
        [Required]
        public virtual Product Product { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        [Required]
        public int Quantity { get; set; }



    }
}
