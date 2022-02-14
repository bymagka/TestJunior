using DAL.BaseEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    /// <summary>
    /// Точка продаж
    /// </summary>
    public class SalesPoint : BaseEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Доступные к продаже товары
        /// </summary>
        public virtual ICollection<ProvidedProduct> ProvidedProducts { get; set; }
    }
}
