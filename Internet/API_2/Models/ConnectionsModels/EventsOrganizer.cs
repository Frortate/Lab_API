using System;
using System.Collections.Generic;

#nullable disable

namespace API_2
{
    public partial class EventsOrganizer
    {
        public EventsOrganizer()
        {
            Sessions = new HashSet<Session>();
        }

        public int Id { get; set; }
        public int EventId { get; set; }
        public int OrganizerId { get; set; }

        public virtual Event Event { get; set; }
        public virtual Organizer Organizer { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
