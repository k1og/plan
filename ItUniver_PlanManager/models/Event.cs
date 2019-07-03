using System;

namespace models
{
    /// <summary>
    /// Событие
    /// </summary>
    public class Event : IEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public Event()
        {
            Uid = new Guid();
        }
        /// <inheritdoc/>
        public Guid Uid { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Place { get; set; }
    }
}
