using System;
using System.Collections.Generic;

#nullable disable

namespace API_2
{
    public partial class Category
    {
        public Category()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
