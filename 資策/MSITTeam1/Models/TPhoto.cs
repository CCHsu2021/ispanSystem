using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TPhoto
    {
        public int FPhotoId { get; set; }
        public string FAccount { get; set; }
        public byte[] FPhoto { get; set; }
        public string FType { get; set; }
    }
}
