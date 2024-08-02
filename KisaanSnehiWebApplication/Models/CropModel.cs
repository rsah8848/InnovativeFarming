using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web;



namespace KisaanSnehiWebApplication.Models
{
    public class CropModel
    {
        /*public CropModel()
        {
            CropPurchases = new HashSet<CropPurchaseModel>();
        }*/

        [DisplayName("Crop Id")]
        public int CropId { get; set; }

        [DisplayName("Farmer Id")]
        public int FarmerId { get; set; }

        [DisplayName("Crop Name")]
        public string CropName { get; set; }

        [DisplayName("Quantity (in Kg)")]
        public double CropQuantity { get; set; }
        public double CropQuantityInStock { get; set; }

        [DisplayName("Description")]
        public string CropDesc { get; set; }

        [DisplayName("Price (per Kg)")]
        public double CropPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        [DisplayName("Image")]
        public string Image { get; set; }

        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile ImageFile { get; set; }

        /*public virtual RegisterationModel Farmer { get; set; }
        public virtual ICollection<CropPurchaseModel> CropPurchases { get; set; }*/
    }
}
