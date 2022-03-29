using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TClassOrderDetail
    {
        public string OrderId { get; set; }
        public string ClassCode { get; set; }
        public int? Price { get; set; }
        public int? Qty { get; set; }
        public double? Discount { get; set; }
    }
}
