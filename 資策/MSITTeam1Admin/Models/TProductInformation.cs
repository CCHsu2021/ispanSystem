using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TProductInformation
    {
        public int ProductId { get; set; }
        public int? Type { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? Cost { get; set; }
        public string ImgPath { get; set; }
        public int? Barcode { get; set; }
    }
}
