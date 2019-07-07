using System.Collections.Generic;
using PlanManagerLib.models;

namespace PlanManagerLib.Interfaces
{
    public interface IUserStore : IStore<User>
    {
        IEnumerable<User> GetByName(string userName);
    }
}