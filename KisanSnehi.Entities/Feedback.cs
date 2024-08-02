using System;
using System.Collections.Generic;

#nullable disable

namespace KisanSnehi.Entities
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int RegId { get; set; }
        public string FeedbackDesc { get; set; }
        public string Status { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        //public virtual Registration Reg { get; set; }
    }
}
