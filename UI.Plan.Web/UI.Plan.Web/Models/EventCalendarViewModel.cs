using System;
using System.Collections.Generic;
using PlanManagerLib.models;

namespace UI.Plan.Web.Models
{
    public class EventCalendarViewModel
    {
        /// <summary>
        /// ctor
        /// </summary>
        public EventCalendarViewModel()
        {
            MonthEvents = new List<Event>();
        }

        /// <summary>
        /// События
        /// </summary>
        public IEnumerable<Event> MonthEvents { get; set; }

        /// <summary>
        /// Сегодняшняя дата
        /// </summary>
        public DateTime Date { get ; set; }
        
        /// <summary>
        /// Количество ячеек
        /// </summary>
        public int DaysInMonth {
            get => DateTime.DaysInMonth(Date.Year, Date.Month);
            set { }
        }

        /// <summary>
        /// Количество колонок (usually days)
        /// </summary>
        public int ColumnCount { get; set; }

        /// <summary>
        /// Количество строк
        /// </summary>
        public int RowCount => (int)Math.Ceiling((DaysInMonth * 1d + (double)Date.DayOfWeek) / ColumnCount);
        
    }
}