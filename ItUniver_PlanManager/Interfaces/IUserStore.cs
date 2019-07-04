using System;
using models;
using System.Collections.Generic;

namespace interfaces
{
    public interface IUserStore : IStore<User>
    {
        IEnumerable<User> GetByName(string userName);
    }
}