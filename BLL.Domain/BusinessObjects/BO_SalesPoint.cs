using System.Collections.Generic;

namespace BLL.Domain.BusinessObjects
{
    /// <summary>
    /// Точка продаж
    /// </summary>
    public class BO_SalesPoint
    {
        /// <summary>
        /// Идентификатор точки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование точки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список доступных к продаже сущностей
        /// </summary>
        public List<BO_ProvidedProduct> ProvidedProducts { get; set; }
    }
}
