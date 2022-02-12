using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.BaseEntities;

namespace DAL.Entities
{
    /// <summary>
    /// Модель акта продажи
    /// </summary>
    public class Sale : BaseEntity
    {
        /// <summary>
        /// Время продажи
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime SalesDate { get; set; }

        /// <summary>
        /// Точка продаж
        /// </summary>
        [ForeignKey("SalesPointId")]
        public SalesPoint SalesPoint { get; set; }

        /// <summary>
        /// Покупатель
        /// </summary>
        [ForeignKey("BuyerId")]
        public Buyer Buyer { get; set; }

        /// <summary>
        /// Данные о проданных товарах
        /// </summary>
        public virtual ICollection<SaleData> SalesData { get; set; }
    }
}
