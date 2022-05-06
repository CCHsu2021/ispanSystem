using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TClassOrder
    {
        public string OrderId { get; set; }
        public string MemberId { get; set; }
        public DateTime? Date { get; set; }
        public int? TotalPrice { get; set; }
        public string PayMethod { get; set; }
        public string Invoice { get; set; }
        public string Taxid { get; set; }
    }
}
