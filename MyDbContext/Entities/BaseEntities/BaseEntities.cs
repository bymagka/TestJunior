
using System.ComponentModel.DataAnnotations;

namespace DAL.BaseEntities
{
    /// <summary>
    /// Базовый класс сущностей базы данных
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Идентификатор сущности. Первичный ключ
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
