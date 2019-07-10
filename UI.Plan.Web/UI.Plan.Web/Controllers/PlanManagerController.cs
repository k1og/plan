using System;
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

        public IActionResult Index(int year, int month) //add Поставщики значений
        {
            if (year < 1 || month < 1 || month > 12)
            {
                year = DateTime.Today.Year;
                month = DateTime.Today.Month;
            }
            var date = new DateTime(year, month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second);

            var events = store.Entities;
            var monthEvents = events.Where(e => e.StartDate?.Month == date.Month && e.StartDate?.Year == date.Year).ToList();
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