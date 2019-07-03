using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace models
{
    /// <summary>
    /// Хранилище событий FILE <see cref="Event"/>
    /// </summary>
    public class EventFileStore : IStore<Event>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public EventFileStore()
        {
            string json = File.ReadAllText(FilePath);
            Events = JsonConvert.DeserializeObject<List<Event>>(json);
            if (Events == null) 
            {
                Events = new List<Event>();
            }
        }

        private string FilePath => @"events.json";

        /// <summary>
        /// Список событий
        /// </summary>
        private List<Event> Events { get; }

        public IEnumerable<Event> Entities => Events;

        /// <summary>
        /// Добавить событие
        /// </summary>
        /// <param name="event">Событие</param>
        public void Add (Event @event) 
        {
            if (@event != null)
            {
                Events.Add(@event);
                File.WriteAllTextAsync(@"events.json", JsonConvert.SerializeObject(Events));
            }
        }

        /// <summary>
        /// Получить событие
        /// </summary>
        /// <param name="uid">Идентификатор события</param>
        public Event Get (Guid uid) 
        {
            return Events.FirstOrDefault(@event => @event.Uid == uid);
        }

        /// <summary>
        /// Обновить событие
        /// </summary>
        /// <param name="event">Событие</param>
        public void Update(Event @event) 
        {
            Delete(@event.Uid);
            Add(@event);
        }

        /// <summary>
        /// Удалить событие
        /// </summary>
        /// <param name="uid">Идентификатор события</param>
        public void Delete (Guid uid) 
        {
            var elem = Get(uid);
            if (elem != null) 
            {
                Events.Remove(elem);
            }
        }
    }
}
