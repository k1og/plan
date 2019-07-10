using System;
using Microsoft.AspNetCore.Mvc;
using PlanManagerLib.Implementations;
using PlanManagerLib.Interfaces;
using PlanManagerLib.models;
using UI.Plan.Web.Models;

namespace UI.Plan.Web.Controllers
{
    public class EventController : Controller
    {
        private IStore<Event> store = new EventFileStore();
        
        public PartialViewResult Details(Guid uid)
        {
            var evt = store.Get(uid);
            
            return PartialView(evt);
        }
        
        public PartialViewResult Edit(Guid uid)
        {
            var evt = store.Get(uid);

            var model = new EventEditViewModel(evt);

            return PartialView(model);
        }
        
        [HttpPost]
        public PartialViewResult Save(EventEditViewModel model)
        {
             if (ModelState.IsValid)
             {
                 var evt = model.GetEvent();
                 try
                 {
                     store.Update(evt);
                     ViewBag.SaveResult = "Успешно сохранено";
                 }
                 catch (Exception ex)
                 {
                     ModelState.AddModelError("", ex.Message);
                 }
             }
             return PartialView("Edit", model);
        }
        
        [HttpGet]
        public EventEditViewModel Add()
        {
            return new EventEditViewModel(new Event());
            //return PartialView("Edit", model);
        }
        
        [HttpPost]
        public void Delete(Guid uid)
        {
            store.Delete(uid);
        }
    }
}