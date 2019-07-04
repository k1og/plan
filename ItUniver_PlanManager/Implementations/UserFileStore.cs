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
            if (user?.Status == UserStatus.Deleted)
            {
                return null;
            }
            return user;
        }

        public override void Delete(Guid uid)
        {
            var user = Get(uid);
            if (user != null) 
            {
                user.Status = UserStatus.Deleted;
                Update(user);
            }
        }
    }
}
