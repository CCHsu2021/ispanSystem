using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TCompanyPoint
    {
        public int PointUsageId { get; set; }
        public string CompanyTaxid { get; set; }
        public string PointDate { get; set; }
        public string PointType { get; set; }
        public string PointDescription { get; set; }
        public int? PointRecord { get; set; }
    }
}
