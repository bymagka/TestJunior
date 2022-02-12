using DAL.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    /// <summary>
    /// Модель данных товара
    /// </summary>
    public class Product : BaseEntity
    {

        /// <summary>
        /// Наименование
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; set; }
    }
}
