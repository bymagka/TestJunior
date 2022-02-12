using System.Collections.Generic;

namespace DAL.Repositories.Interfaces
{
    /// <summary>
    /// Базовые операции взаимодействия с контекстом
    /// </summary>
    /// <typeparam name="T">любой тип</typeparam>
    public interface IRepo <T>
    {
        /// <summary>
        /// Добавляет сущность
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <returns>Признак успешности добавления сущности</returns>
        bool Add(T entity);

        /// <summary>
        /// Добавляет список сущностей
        /// </summary>
        /// <param name="entities">Список объектов</param>
        /// <returns>Признак успешного добавления сущностей</returns>
        bool Add(ICollection<T> entities);

        /// <summary>
        /// Получает объект из контекста по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор для поиска</param>
        /// <returns>Найденный объект</returns>
        T GetOne(int id);

        /// <summary>
        /// Обновляет данные по объекту
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
        /// <returns>Признак успешности обновления</returns>
        bool Update(T entity);

        /// <summary>
        /// Удаляет данные по объекту
        /// </summary>
        /// <param name="entity">Удаляемая сущность</param>
        /// <returns>Признак успешности удаления</returns>
        bool Delete(T entity);

        /// <summary>
        /// Получает список всех сущностей типа
        /// </summary>
        /// <returns></returns>
        ICollection<T> GetAll();
        


    }
}
