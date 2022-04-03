using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TTestResult
    {
        public int FResultId { get; set; }
        public string FMemberAccount { get; set; }
        public DateTime FTestDateTime { get; set; }
        public int? FTypeInfoId { get; set; }
        public byte[] FTypeInfoImage { get; set; }
        public int? FTestGrade { get; set; }
        public int FTestPaperId { get; set; }
    }
}
