using System;
using System.Collections.Generic;

#nullable disable

namespace KisanSnehi.Entities
{
    public partial class UserType
    {
       /* public UserType()
        {
            Registrations = new HashSet<Registration>();
        }*/

        public int UserTypeId { get; set; }
        public string UserType1 { get; set; }

     //   public virtual ICollection<Registration> Registrations { get; set; }
    }
}
