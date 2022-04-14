using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TProduct
    {
        public string ProductId { get; set; }
        public int? Type { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public int? Cost { get; set; }
        public string ImgPath { get; set; }
        public string Description { get; set; }
        public int? Barcode { get; set; }
        public int? InStock { get; set; }
        public int? Active { get; set; }
    }
}
