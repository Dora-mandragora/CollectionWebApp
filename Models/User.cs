using System;
using System.Collections.Generic;

namespace CollectionWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }

        public Role Role { get; set; }
        public Status Status { get; set; }
        public ItemHistory ItemHistory { get; set; }

        public ICollection<Collection> Collections { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
