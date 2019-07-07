using System;
using System.Collections.Generic;
using System.Linq;
using PlanManagerLib.Interfaces;
using PlanManagerLib.models;

namespace PlanManagerLib.Implementations
{
    /// <summary>
    /// Хранилище пользователй FILE <see cref="user"/>
    /// </summary>
    public class UserFIleStore : BaseFileStore<User> , IUserStore
    {
        public IEnumerable<User> GetByName(string userName)
        {
            return Entities.Where(user => user.Status != UserStatus.Deleted && user.Name.Contains(userName));
        }

        public override User Get(Guid uid)
        {
            var user = base.Get(uid);
            return user?.Status == UserStatus.Deleted ? null : user;
        }

        public override void Delete(Guid uid)
        {
            var user = Get(uid);
            if (user == null) return;
            user.Status = UserStatus.Deleted;
            Update(user);
        }
    }
}
