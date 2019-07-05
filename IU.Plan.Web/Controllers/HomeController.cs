using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IU.Plan.Web.Models;

using models;
using interfaces;
using implementations;

namespace IU.Plan.Web.Controllers
{
    public class HomeController : Controller
    {
        IStore<Event> store = new EventFileStore();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Calendar() 
        {
            var events = store.Entities;
            List<Event> thisWeekEvents = new List<Event>();
            var thisDayOfWeek = DateTime.Now.DayOfWeek;
            //var thisDayOfYear = DateTime.Now.DayOfYear;
            //var plus = 7 - thisDayOfWeek;
            //var minus = -(thisDayOfWeek - 1);
            foreach (var e in events)
            {
                /*
                var startDateDayOfWeek = e.StartDate.Value.DayOfYear % 7;
                var startDateDayOfYear = e.StartDate.Value.DayOfYear;
                var diff = Math.Abs(thisDayOfYear - thisDayOfYear);
                if (thisDayOfWeek + plus >= diff && thisDayOfWeek + minus <= diff) 
                {
                    thisWeekEvents.Add(e);
                }
                */
                if (DatesAreInTheSameWeek(e.StartDate.Value, DateTime.Now))
                {
                    thisWeekEvents.Add(e);                    
                }
            }
            return View(new EventsCalendarViewModel { 
                WeekEvents = thisWeekEvents,
                DayOfWeek = thisDayOfWeek
                });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static bool DatesAreInTheSameWeek(DateTime date1, DateTime date2)
        {
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var d1 = date1.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date1));
            var d2 = date2.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date2));

            return d1 == d2;
        }
    }
}
