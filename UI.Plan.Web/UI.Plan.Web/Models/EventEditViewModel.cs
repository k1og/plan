using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PlanManagerLib.models;

namespace UI.Plan.Web.Models
{
    public class EventEditViewModel
    {
        public EventEditViewModel()
        {
            
        }
        
        public EventEditViewModel(Event evt)
        {
            if (evt == null)
            {
                return;
            }

            Uid = evt.Uid;
            Title = evt.Title;
            Description = evt.Description;
            StartDate = evt.StartDate;
            EndDate = evt.EndDate;
            Place = evt.Place;
        }

        public Event GetEvent()
        {
            return new Event
            {
                Uid = Uid,
                Title = Title,
                Description = Description,
                StartDate = StartDate,
                EndDate = EndDate,
                Place = Place
            };
        }

        [HiddenInput(DisplayValue = false)]
        public Guid Uid { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Без названия ничего нельзя сделать")]
        public string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// Начало периода
        /// </summary>
        [Display(Name = "с")]
        [Required(ErrorMessage = "Нам нужно знать когда это произойдет")]
        [DataType(DataType.DateTime)]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Окончание периода
        /// </summary>
        [Display(Name = "по")]
        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Место 
        /// </summary>
        [Display(Name = "Где")]
        public string Place { get; set; }
    }
}