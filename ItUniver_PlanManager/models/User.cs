using System;
using interfaces;

namespace models
{
    //add summary
    public class User : IEntity
    {
        /// <inheritdoc>
        public Guid Uid { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Photo { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// Принимать приглашения
        /// </summary>
        public bool AllowInvites { get; set; }
        
        public Gender Gender { get; set; }

        public UserStatus Status { get; set; }
    }

    public enum UserStatus
    {
        Active,
        Deleted
    }

    public enum Gender
    {
        Undefined,
        Man,
        Woman
    }
}