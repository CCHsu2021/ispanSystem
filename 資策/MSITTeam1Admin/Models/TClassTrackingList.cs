using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TClassTrackingList
    {
        public string MemberId { get; set; }
        public string ProductId { get; set; }
        public int? Price { get; set; }
        public string ImgPath { get; set; }
        public string Name { get; set; }
    }
}
