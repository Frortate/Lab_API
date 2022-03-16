using System;
using System.Collections.Generic;

#nullable disable

namespace API_2
{
    public partial class Place
    {
        public Place()
        {
            Organizers = new HashSet<Organizer>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Organizer> Organizers { get; set; }
    }
}
