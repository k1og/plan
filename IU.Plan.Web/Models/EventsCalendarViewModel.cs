using System;
using System.Collections.Generic;

using models;
using interfaces;
using implementations;

namespace IU.Plan.Web.Models
{
    public class EventsCalendarViewModel
    {
        public List<Event> WeekEvents { get; set; }

        public DayOfWeek DayOfWeek {get; set;} //rewrite enum
    }
}