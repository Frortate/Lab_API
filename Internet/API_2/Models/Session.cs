using System;
using System.Collections.Generic;

#nullable disable

namespace API_2
{
    public partial class Session
    {
        public Session()
        {
            UsersSessions = new HashSet<UsersSession>();
        }

        public int Id { get; set; }
        public int EventsOrganizersId { get; set; }
        public DateTime Date { get; set; }

        public virtual EventsOrganizer EventsOrganizers { get; set; }
        public virtual ICollection<UsersSession> UsersSessions { get; set; }
    }
}
