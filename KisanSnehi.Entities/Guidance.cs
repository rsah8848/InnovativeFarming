using System;
using System.Collections.Generic;

#nullable disable

namespace KisanSnehi.Entities
{
    public partial class Guidance
    {
        public int GuidanceId { get; set; }
        public int FromMonth { get; set; }
        public int ToMonth { get; set; }
        public string CropName { get; set; }
        public string CropDesc { get; set; }
        public string Image { get; set; }
    }
}
