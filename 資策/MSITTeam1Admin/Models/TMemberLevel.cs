using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TMemberLevel
    {
        public int FLevel { get; set; }
        public string Title { get; set; }
        public double? BonusPercent { get; set; }
    }
}
