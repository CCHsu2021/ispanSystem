using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TPointOrder
    {
        public string CompanyTaxid { get; set; }
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int? BuyPoint { get; set; }
        public string PayMethod { get; set; }
        public double? Bonus { get; set; }
        public int? ToTalGetPoint { get; set; }
    }
}
