using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TMemberPoint
    {
        public string FAccount { get; set; }
        public int PointUsageId { get; set; }
        public string PointDate { get; set; }
        public string PointType { get; set; }
        public string PointDescription { get; set; }
        public int? PointRecord { get; set; }
    }
}
