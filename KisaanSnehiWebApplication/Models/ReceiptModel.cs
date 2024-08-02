using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisaanSnehiWebApplication.Models
{
    public class ReceiptModel
    {
        public int FarmerID { get; set; }
        public int NumberOfItems { get; set; }
        public double TotalBill { get; set; }
        public DateTime? ReciptDate { get; set; }
    }
}
