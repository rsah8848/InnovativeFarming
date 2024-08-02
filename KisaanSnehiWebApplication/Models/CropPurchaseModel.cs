using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KisaanSnehiWebApplication.Models
{
    public class CropPurchaseModel
    {
        public int CropPurchaseId { get; set; }
        public int FarmerId { get; set; }
        public int SupplierId { get; set; }
        public int CropId { get; set; }
        [DisplayName("Purchased Quantity")]
        public double CropPurchaseQuantity { get; set; }
        [DisplayName("Total Bill")]
        public double CropBillAmount { get; set; }
        [DisplayName("Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime CropPurchaseDate { get; set; }

        [DisplayName("Crop Name")]
        public string CropName { get; set; }

        [DisplayName("Contact")]
        public long PhoneNo { get; set; }

        [DisplayName("Supplier Name")]
        public string SupplierName { get; set; }

        [DisplayName("Farmer Name")]
        public string FarmerName { get; set; }

        [DisplayName("Purchase Date")]
        public string DateOfPurchase { get; set; } 

        /*public virtual CropModel Crop { get; set; }
        public virtual RegisterationModel Farmer { get; set; }
        public virtual RegisterationModel Supplier { get; set; }*/
    }
}
