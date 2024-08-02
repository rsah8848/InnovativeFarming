using System;
using System.Collections.Generic;

#nullable disable

namespace KisanSnehi.Entities
{
    public partial class CropPurchase
    {
        public int CropPurchaseId { get; set; }
        public int FarmerId { get; set; }
        public int SupplierId { get; set; }
        public int CropId { get; set; }
        public double CropPurchaseQuantity { get; set; }
        public double CropBillAmount { get; set; }
        public DateTime CropPurchaseDate { get; set; }

        /*public virtual Crop Crop { get; set; }
        public virtual Registration Farmer { get; set; }
        public virtual Registration Supplier { get; set; }*/
    }
}
