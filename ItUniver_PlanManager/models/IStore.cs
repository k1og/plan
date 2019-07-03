using System;
using System.Collections.Generic;

namespace models
{
    public interface IEntity
    {
        Guid Uid { get; set; }
    }
    public interface IStore<T> where T : class, IEntity
    {
        IEnumerable<T> Entities { get; }

        /// <summary>
        /// Добавить сущность
        /// </summary>
        /// <param name="event">сущность</param>
        void Add (T entity);

        /// <summary>
        /// Получить сущность
        /// </summary>
        /// <param name="uid">Идентификатор сущности</param>
        T Get (Guid uid);
        
        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="event">Событие</param>
        void Update(T entity);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="uid">Идентификатор сущности</param>
        void Delete (Guid uid);
    }
}