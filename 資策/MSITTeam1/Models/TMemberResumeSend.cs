using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TMemberResumeSend
    {
        public TMemberResumeSend()
        {
            TCompanyResponds = new HashSet<TCompanyRespond>();
        }

        public string ResumeSendId { get; set; }
        public int JobId { get; set; }
        public long ResumeId { get; set; }
        public string MemberId { get; set; }
        public string CompanyTaxid { get; set; }
        public string JobName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string ComReadOrNot { get; set; }
        public string TimeToContact { get; set; }
        public string CoverLetter { get; set; }
        public string CreatTime { get; set; }
        public string ModifyTime { get; set; }

        public virtual ICollection<TCompanyRespond> TCompanyResponds { get; set; }
    }
}
