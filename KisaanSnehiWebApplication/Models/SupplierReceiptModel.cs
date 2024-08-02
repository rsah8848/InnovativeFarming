using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KisaanSnehiWebApplication.Models
{
    public class SupplierReceiptModel
    {
        public int SupplierID { get; set; }

        [DisplayName("Number Of Items")]
        public int NumberOfItems { get; set; }

        [DisplayName("Total Bill")]
        public double TotalBill { get; set; }

        [DisplayName("Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime? ReciptDate { get; set; }
    }
}
