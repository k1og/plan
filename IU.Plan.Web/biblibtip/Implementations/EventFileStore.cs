using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using models;
using interfaces;

namespace implementations
{
    /// <summary>
    /// Хранилище событий FILE <see cref="Event"/>
    /// </summary>
    public class EventFileStore : BaseFileStore<Event> ,IStore<Event>
    {
        
    }
}
