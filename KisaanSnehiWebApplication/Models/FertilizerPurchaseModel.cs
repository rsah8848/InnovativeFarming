using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace KisaanSnehiWebApplication.Models
{
    public class FertilizerPurchaseModel
    {
        public int FertilizerPurchaseId { get; set; }
        public int FarmerId { get; set; }
        public int TraderId { get; set; }
        public int FertilizerId { get; set; }
        [DisplayName("Purchased Quantity")]
        
        public double FertilizerPurchaseQuantity { get; set; }
        [DisplayName("Total Bill")]
        public double FertilizerBillAmount { get; set; }
        [DisplayName("Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime? FertilizerPurchaseDate { get; set; }
        [DisplayName("Fertilizer Name")]
        
        public string FertilizerName { get; set; }
        [DisplayName("Contact")]
        public long PhoneNo { get; set; }
        [DisplayName("Farmer Name")]
        public string FarmerName { get; set; }
        

        /*public virtual FertilizerModel Farmer { get; set; }
        public virtual RegisterationModel FarmerNavigation { get; set; }
        public virtual RegisterationModel Trader { get; set; }*/
    }
}
