
using System.Collections.Generic;


namespace BLL.Services
{
    /// <summary>
    /// Базовые операции CRUD-интерфейса
    /// </summary>
    /// <typeparam name="T">Основной тип сервиса</typeparam>
    public interface IBaseService<T> where T: class
    {
        /// <summary>
        /// Добавление бизнес объекта
        /// </summary>
        /// <param name="product">Бизнес объект</param>
        /// <returns>Флаг успешности операции</returns>
        bool Add(T businessObject);

        /// <summary>
        /// Получение бизнес объекта по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>Модель найденного объекта. Если не найдено - null</returns>
        T Get(int id);

        /// <summary>
        /// Возвращает список всех бизнес объектов указанного типа
        /// </summary>
        /// <returns>Коллекция всех объектов типа</returns>
        ICollection<T> GetAll();

        /// <summary>
        /// Обновляет данные объекта
        /// </summary>
        /// <param name="product">Обновляемый объект</param>
        /// <returns>Признак успешности обновления</returns>
        bool Update(T businessObject);

        /// <summary>
        /// Удаляет объект по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор товара</param>
        /// <returns>Признак успешности удаления</returns>
        bool Delete(int id);
    }
}
