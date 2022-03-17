using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TClassGrade
    {
        public string FAccount { get; set; }
        public string FMemberName { get; set; }
        public int? FBeforeClassGrade { get; set; }
        public int? FAfterClassGrade { get; set; }
        public int? FTestPaperId { get; set; }
        public int? FIscompany { get; set; }
    }
}
