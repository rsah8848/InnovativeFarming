using System;
using System.Collections.Generic;

#nullable disable

namespace KisanSnehi.Entities
{
    public partial class FertilizerPurchase
    {
        public int FertilizerPurchaseId { get; set; }
        public int FarmerId { get; set; }
        public int TraderId { get; set; }
        public int FertilizerId { get; set; }
        public double FertilizerPurchaseQuantity { get; set; }
        public double FertilizerBillAmount { get; set; }
        public DateTime FertilizerPurchaseDate { get; set; }

       /* public virtual Fertilizer Farmer { get; set; }
        public virtual Registration FarmerNavigation { get; set; }
        public virtual Registration Trader { get; set; }*/
    }
}
