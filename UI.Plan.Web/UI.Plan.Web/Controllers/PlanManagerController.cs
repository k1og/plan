using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlanManagerLib.Implementations;
using PlanManagerLib.Interfaces;
using PlanManagerLib.models;
using UI.Plan.Web.Models;

namespace UI.Plan.Web.Controllers
{
    public class PlanManagerController : Controller
    {
        IStore<Event> store = new EventFileStore();

        public IActionResult Index(int year, int month)
        {
            var date = new DateTime(year, month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second);

            var startMonth = new DateTime(date.Year, date.Month, 1);
            var endMonth = startMonth.AddMonths(1);
            var events = store.Entities;
            var monthEvents = events.Where(e => e.StartDate.HasValue).Where(e => e.StartDate.Value.Month == date.Month && e.StartDate.Value.Year == date.Year).ToList();
            var model = new EventCalendarViewModel
            {
                MonthEvents = monthEvents,
                Date = date,
                ColumnCount = 7
            };
            return View(model);
        }
    }
}