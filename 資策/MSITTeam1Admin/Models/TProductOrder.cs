using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TProductOrder
    {
        public string OrderId { get; set; }
        public string MemberId { get; set; }
        public DateTime? Date { get; set; }
        public int? TotalPrice { get; set; }
        public int? PayMethod { get; set; }
        public int? ShipBy { get; set; }
        public string ShipTo { get; set; }
        public string Invoice { get; set; }
    }
}
