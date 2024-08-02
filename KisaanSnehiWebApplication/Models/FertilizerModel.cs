using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace KisaanSnehiWebApplication.Models
{
    public class FertilizerModel
    {
        /*public FertilizerModel()
        {
            FertilizerPurchases = new HashSet<FertilizerPurchaseModel>();
        }*/

        public int FertilizerId { get; set; }
        public int TraderId { get; set; }
        [DisplayName("Crop Name")]
        
        public string FertilizerName { get; set; }
        [DisplayName("Quantity (in Kg)")]
        
        public double FertilizerQuantity { get; set; }
        
        public double FertilizerQuantityInStock { get; set; }
        [DisplayName("Description")]
        public string FertilizerDesc { get; set; }
        [DisplayName("Price (per Kg)")]
        public double FertilizerPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        [DisplayName("Image")]
        public string Image { get; set; }

        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile ImageFile { get; set; }

        /*public virtual RegisterationModel Trader { get; set; }
        public virtual ICollection<FertilizerPurchaseModel> FertilizerPurchases { get; set; }*/
    }
}
