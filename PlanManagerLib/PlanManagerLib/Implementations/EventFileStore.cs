using PlanManagerLib.Interfaces;
using PlanManagerLib.models;

namespace PlanManagerLib.Implementations
{
    /// <summary>
    /// Хранилище событий FILE <see cref="Event"/>
    /// </summary>
    public class EventFileStore : BaseFileStore<Event> ,IStore<Event>
    {
        
    }
}
