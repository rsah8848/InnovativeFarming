using System;
using System.Collections.Generic;

#nullable disable

namespace KisaanSnehiWebApplication.Models
{
    public partial class GuidanceModel
    {
        public int GuidanceId { get; set; }
        public int FromMonth { get; set; }
        public int ToMonth { get; set; }
        public string CropName { get; set; }
        public string CropDesc { get; set; }
        public string Image { get; set; }
    }
}
