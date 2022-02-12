using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Domain.BusinessObjects
{
    /// <summary>
    /// Бизнес модель покупателя
    /// </summary>
    public class BO_Buyer
    {
        /// <summary>
        /// Идентификатор покупателя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя покупателя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список идентификаторов всех когда либо осуществленных покупок
        /// </summary>
        public List<int> SalesIds { get; set; }
    }
}
