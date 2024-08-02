using System;
using System.Collections.Generic;

#nullable disable

namespace KisaanSnehiWebApplication.Models
{
    public class LocationModel
    {
        /*public LocationModel()
        {
            Registerations = new HashSet<RegisterationModel>();
        }*/

        public int LocationId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long Pin { get; set; }

        /*public virtual ICollection<RegisterationModel> Registerations { get; set; }*/
    }
}
