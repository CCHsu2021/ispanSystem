using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TOrderDetail
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int? Price { get; set; }
        public int? Qty { get; set; }
    }
}
