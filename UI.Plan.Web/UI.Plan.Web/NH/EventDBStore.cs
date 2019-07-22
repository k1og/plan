using System;
using System.Collections.Generic;
using System.Linq;
using PlanManagerLib.models;

namespace UI.Plan.Web.NH
{
    /// <summary>
    /// Хранилище событий <see cref="Event"/>
    /// </summary>
    public class EventDBStore<T> : BaseDBStore<T> where T :  Event
    {
        
    }
}