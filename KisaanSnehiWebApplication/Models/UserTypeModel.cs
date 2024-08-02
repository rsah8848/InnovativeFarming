using System;
using System.Collections.Generic;

#nullable disable

namespace KisaanSnehiWebApplication.Models
{
    public class UserTypeModel
    {
        /*public UserTypeModel()
        {
            Registerations = new HashSet<RegisterationModel>();
        }*/

        public int UserTypeId { get; set; }
        public string UserType1 { get; set; }

        /*public virtual ICollection<RegisterationModel> Registerations { get; set; }*/
    }
}
