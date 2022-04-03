using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TClassOrder
    {
        public string OrderId { get; set; }
        public string MemberId { get; set; }
        public string Date { get; set; }
        public int? TotalPrice { get; set; }
        public int? PayMethod { get; set; }
        public string Invoice { get; set; }
    }
}
