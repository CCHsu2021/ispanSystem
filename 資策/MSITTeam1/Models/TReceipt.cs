using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TReceipt
    {
        public int FId { get; set; }
        public string MemberId { get; set; }
        public string OrderId { get; set; }
        public int? OrderType { get; set; }
        public int? ReceiptType { get; set; }
        public string ReceiptTitle { get; set; }
        public string CompanyTaxid { get; set; }
        public int? Vegetarian { get; set; }
        public string EmergencyContactPerson { get; set; }
        public string EmergencyContactPersonPhone { get; set; }
        public string EmergencyContactPersonEmail { get; set; }
        public string NewsFrom { get; set; }
        public string Undertaker { get; set; }
        public string UndertakerPhone { get; set; }
        public string UndertakerEmail { get; set; }
        public string Note { get; set; }
    }
}
