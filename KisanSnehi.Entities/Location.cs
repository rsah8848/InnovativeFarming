using System;
using System.Collections.Generic;

#nullable disable

namespace KisanSnehi.Entities
{
    public partial class Location
    {
        //public Location()
        //{
        //    Registrations = new HashSet<Registration>();
        //}

        public int LocationId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long Pin { get; set; }

       //public virtual ICollection<Registration> Registrations { get; set; }
    }
}
