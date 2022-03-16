using System;
using System.Collections.Generic;

#nullable disable

namespace API_2
{
    public partial class Event
    {
        public Event()
        {
            EventsOrganizers = new HashSet<EventsOrganizer>();
        }
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Site { get; set; }
        public byte[] Poster { get; set; }
        public bool IsNew { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
        public int AgeId { get; set; }

        public virtual Age Age { get; set; }
        public virtual Category Category { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<EventsOrganizer> EventsOrganizers { get; set; }
    }
}
