using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace KisaanSnehiWebApplication.Models
{ 
    public class FeedbackModel
    {
        public int FeedbackId { get; set; }
        public int RegId { get; set; }
        [StringLength(200, ErrorMessage = "limit exceeded")]
        public string FeedbackDesc { get; set; }
        public string Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime  UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        /*public virtual RegisterationModel Reg { get; set; }*/
    }
}
