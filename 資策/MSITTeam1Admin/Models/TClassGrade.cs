using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TClassGrade
    {
        public string FAccountId { get; set; }
        public string FClassCode { get; set; }
        public int? FBeforeClassGrade { get; set; }
        public DateTime? FBeforeClassTime { get; set; }
        public int? FAfterClassGrade { get; set; }
        public DateTime? FAfterClassTime { get; set; }
    }
}
