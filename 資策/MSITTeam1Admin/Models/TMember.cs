using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TMember
    {
        public TMember()
        {
            TClassOrders = new HashSet<TClassOrder>();
        }

        public string FAccount { get; set; }
        public byte[] FPassword { get; set; }
        public byte[] FSalt { get; set; }
        public int? FMemberType { get; set; }
        public string FGuid { get; set; }
        public string FDateTime { get; set; }

        public virtual ICollection<TClassOrder> TClassOrders { get; set; }
    }
}
