using System;
using System.Collections.Generic;

#nullable disable

namespace KisanSnehi.Entities
{
    public partial class Fertilizer
    {
       /* public Fertilizer()
        {
            FertilizerPurchases = new HashSet<FertilizerPurchase>();
        }*/

        public int FertilizerId { get; set; }
        public int TraderId { get; set; }
        public string FertilizerName { get; set; }
        public double FertilizerQuantity { get; set; }
        public double FertilizerQuantityInStock { get; set; }
        public string FertilizerDesc { get; set; }
        public double FertilizerPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Image { get; set; }

       /* public virtual Registration Trader { get; set; }
        public virtual ICollection<FertilizerPurchase> FertilizerPurchases { get; set; }*/
    }
}
