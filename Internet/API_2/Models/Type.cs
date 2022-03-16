using System;
using System.Collections.Generic;

#nullable disable

namespace API_2
{
    public partial class Type
    {
        public Type()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
