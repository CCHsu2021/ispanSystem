using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TOrderInformation
    {
        public string FAccount { get; set; }
        public int OrderId { get; set; }
        public string Date { get; set; }
        public decimal? TotalPrice { get; set; }
        public string PayMethod { get; set; }
        public string ShipBy { get; set; }
        public string ShipTo { get; set; }
        public string Invoice { get; set; }

        public virtual TMember FAccountNavigation { get; set; }
    }
}
