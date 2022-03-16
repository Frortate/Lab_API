using System;
using System.Collections.Generic;

#nullable disable

namespace API_2
{
    public partial class City
    {
        public City()
        {
            Places = new HashSet<Place>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Place> Places { get; set; }
    }
}
