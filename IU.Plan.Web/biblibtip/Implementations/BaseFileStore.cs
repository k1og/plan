using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using interfaces;

namespace implementations
{
    /// <summary>
    /// Хранилище сущностей FILE <see cref="entity"/>
    /// </summary>
    public class BaseFileStore<T> : IStore<T> where T : class, IEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public BaseFileStore()
        {
            entities = new List<T>();
            Init();
        }

        /// <summary>
        /// Загрузка данных из файла
        /// </summary>
        protected virtual void Init()
        {
            if (File.Exists(FilePath))
            {
                var file = File.ReadAllText(FilePath);
                var entities = JsonConvert.DeserializeObject<T[]>(file);
                this.entities.AddRange(entities);
            }
        }

        /// <summary>
        /// write into file
        /// </summary>
        protected virtual void Flush()
        {
            File.WriteAllTextAsync(FilePath, JsonConvert.SerializeObject(entities));
        }
        
        private string fileName = "{0}.json";

        protected virtual string FilePath { 
            get 
            { 
                return string.Format(fileName, typeof(T).Name.ToLower());
            }

            set 
            {

            }
        }

        /// <summary>
        /// Список сущностей
        /// </summary>
        private List<T> entities { get; }

        public IEnumerable<T> Entities => entities;

        /// <summary>
        /// Добавить сущность
        /// </summary>
        /// <param name="entity">Сущность</param>
        public virtual void Add (T entity) 
        {
            if (entity != null)
            {
                entities.Add(entity);
                Flush();
            }
        }

        /// <summary>
        /// Получить сущность
        /// </summary>
        /// <param name="uid">Идентификатор события</param>
        public virtual T Get (Guid uid) 
        {
            return entities.FirstOrDefault(entity => entity.Uid == uid);
        }

        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="entity">Сущность</param>
        public virtual void Update(T entity) 
        {
            Delete(entity.Uid);
            Add(entity);
        }

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="uid">Идентификатор сущности</param>
        public virtual void Delete (Guid uid) 
        {
            var elem = Get(uid);
            if (elem != null) 
            {
                entities.Remove(elem);
                Flush();
            }
        }
    }
}
