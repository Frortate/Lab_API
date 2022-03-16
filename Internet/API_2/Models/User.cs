using System;
using System.Collections.Generic;

#nullable disable

namespace API_2
{
    public partial class User
    {
        public User()
        {
            UsersSessions = new HashSet<UsersSession>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UsersSession> UsersSessions { get; set; }
    }
}
