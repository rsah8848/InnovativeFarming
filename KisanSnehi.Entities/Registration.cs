using System;
using System.Collections.Generic;

#nullable disable

namespace KisanSnehi.Entities
{
    public partial class Registration
    {
       /* public Registration()
        {
            CropPurchaseFarmers = new HashSet<CropPurchase>();
            CropPurchaseSuppliers = new HashSet<CropPurchase>();
            Crops = new HashSet<Crop>();
            Feedbacks = new HashSet<Feedback>();
            FertilizerPurchaseFarmerNavigations = new HashSet<FertilizerPurchase>();
            FertilizerPurchaseTraders = new HashSet<FertilizerPurchase>();
            Fertilizers = new HashSet<Fertilizer>();
        }*/

        public int RegId { get; set; }
        public int UserTypeId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public long PhoneNo { get; set; }
        public string Address { get; set; }
        public int LocationId { get; set; }
        public string Password { get; set; }
        public string SecurityQue { get; set; }
        public string Answer { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Image { get; set; }

       /* public virtual Location Location { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual ICollection<CropPurchase> CropPurchaseFarmers { get; set; }
        public virtual ICollection<CropPurchase> CropPurchaseSuppliers { get; set; }
        public virtual ICollection<Crop> Crops { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<FertilizerPurchase> FertilizerPurchaseFarmerNavigations { get; set; }
        public virtual ICollection<FertilizerPurchase> FertilizerPurchaseTraders { get; set; }
        public virtual ICollection<Fertilizer> Fertilizers { get; set; }*/
    }
}
