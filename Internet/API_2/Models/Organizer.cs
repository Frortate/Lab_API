using System;
using System.Collections.Generic;

#nullable disable

namespace API_2
{
    public partial class Organizer
    {
        public Organizer()
        {
            EventsOrganizers = new HashSet<EventsOrganizer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Site { get; set; }
        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }
        public virtual ICollection<EventsOrganizer> EventsOrganizers { get; set; }
    }
}
