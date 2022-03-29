using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TCompanyRespond
    {
        public long CompanyRespondId { get; set; }
        public long ResumeSendId { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonPhone { get; set; }
        public string ContactPersonEmail { get; set; }
        public string ContactPersonFax { get; set; }
        public string InterviewState { get; set; }
        public string InterviewTime { get; set; }
        public string InterviewAddress { get; set; }
        public string MemberRespondTime { get; set; }
        public string InterviewContent { get; set; }
        public string CreatTime { get; set; }
        public string ModifyTime { get; set; }

        public virtual TMemberResumeSend ResumeSend { get; set; }
    }
}
