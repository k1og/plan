using System;
using System.Collections.Generic;
using System.Linq;
using PlanManagerLib.Interfaces;
using PlanManagerLib.models;

namespace PlanManagerLib.Implementations
{
    /// <summary>
    /// Хранилище событий <see cref="Event"/>
    /// </summary>
    public class EventStore : IStore<Event>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public EventStore()
        {
            Events = new List<Event>();
        }

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
