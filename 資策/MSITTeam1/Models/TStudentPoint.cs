using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TStudentPoint
    {
        public int PointUsageId { get; set; }
        public string MemberId { get; set; }
        public DateTime? PointDate { get; set; }
        public string PointType { get; set; }
        public string PointDescription { get; set; }
        public string PointRecord { get; set; }
        public string OrderId { get; set; }
    }
}
