using DAL.BaseEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    /// <summary>
    /// Модель покупателя
    /// </summary>
    public class Buyer : BaseEntity
    {
        /// <summary>
        /// Имя покупателя
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Идентификаторы покупок, когда либо осуществляемых покупателем
        /// </summary>
        public virtual ICollection<int> SalesIds { get; set; }
    }
}
