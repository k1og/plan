using System;
using PlanManagerLib.Interfaces;

namespace PlanManagerLib.models
{
    //add summary
    public class User : IEntity
    {
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Photo { get; set; }

        public string Email { get; set; }

        /// <summary>
        ///     Принимать приглашения
        /// </summary>
        public bool AllowInvites { get; set; }

        public Gender Gender { get; set; }

        public UserStatus Status { get; set; }

        /// <inheritdoc />
        public Guid Uid { get; set; }
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