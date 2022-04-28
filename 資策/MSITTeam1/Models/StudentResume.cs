using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class StudentResume
    {
        public long ResumeId { get; set; }
        public string MemberId { get; set; }
        public string ResumeName { get; set; }
        public int? ResumeStyle { get; set; }
        public string RBasic { get; set; }
        public string RWorkExp { get; set; }
        public string REducation { get; set; }
        public string RSkill { get; set; }
        public string RLanguage { get; set; }
        public string RPortfolio { get; set; }
    }
}
