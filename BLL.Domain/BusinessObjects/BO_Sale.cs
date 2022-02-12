using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Domain.BusinessObjects
{
    /// <summary>
    /// Акт продажи
    /// </summary>
    public class BO_Sale
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата осуществления продажи
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Время осуществления продажи
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Идентификатор точки продажи
        /// </summary>
        public int SalesPointId { get; set; }

        /// <summary>
        /// Идентификатор покупателя
        /// </summary>
        public int? BuyerId { get; set; }

        /// <summary>
        /// Данные о проданных товарах
        /// </summary>
        public List<BO_SaleData> SalesData { get; set; }

        /// <summary>
        /// Общая сумма всей покупки
        /// </summary>
        public decimal TotalAmount { get => SalesData.Sum((sd)=>sd.ProductIdAmount); }
    }
}
