using System;
using System.Collections.Generic;

#nullable disable

namespace API_2
{
    public partial class UsersSession
    {
        public int UserId { get; set; }
        public int SessionId { get; set; }

        public virtual Session Session { get; set; }
        public virtual User User { get; set; }
    }
}
