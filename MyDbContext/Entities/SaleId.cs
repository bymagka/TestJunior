

namespace DAL.Entities
{
    /// <summary>
    /// Данные о когда либо проданных товарах
    /// </summary>
    public class SaleId : BaseEntities.BaseEntity
    {
        /// <summary>
        /// Значение ID заказов
        /// </summary>
        public int Value { get; set; }
    }
}
