using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TProductOrder
    {
        public string OrderId { get; set; }
        public string MemberId { get; set; }
        public DateTime? Date { get; set; }
        public string TotalPrice { get; set; }
        public int? PayMethod { get; set; }
        public int? ShipBy { get; set; }
        public string ShipTo { get; set; }
        public string Invoice { get; set; }
        public string Recipient { get; set; }
        public string RecipientTel { get; set; }
        public string Taxid { get; set; }
    }
}
