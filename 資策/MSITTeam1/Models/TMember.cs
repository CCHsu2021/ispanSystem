using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TMember
    {
        public TMember()
        {
            TOrderInformations = new HashSet<TOrderInformation>();
        }

        public string FAccount { get; set; }
        public byte[] FPassword { get; set; }
        public byte[] FSalt { get; set; }
        public int? FMemberType { get; set; }

        public virtual ICollection<TOrderInformation> TOrderInformations { get; set; }
    }
}
