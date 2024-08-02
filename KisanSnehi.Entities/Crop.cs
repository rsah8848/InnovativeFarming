using System;
using System.Collections.Generic;

#nullable disable

namespace KisanSnehi.Entities
{
    public partial class Crop
    {
       /* public Crop()
        {
            CropPurchases = new HashSet<CropPurchase>();
        }
*/
        public int CropId { get; set; }
        public int FarmerId { get; set; }
        public string CropName { get; set; }
        public double CropQuantity { get; set; }
        public double CropQuantityInStock { get; set; }
        public string CropDesc { get; set; }
        public double CropPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Image { get; set; }

      /*  public virtual Registration Farmer { get; set; }
        public virtual ICollection<CropPurchase> CropPurchases { get; set; }*/
    }
}
