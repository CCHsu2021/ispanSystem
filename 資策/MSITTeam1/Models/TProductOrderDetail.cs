using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TProductOrderDetail
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int? Price { get; set; }
        public int? Qty { get; set; }
        public double? Discount { get; set; }
    }
}
