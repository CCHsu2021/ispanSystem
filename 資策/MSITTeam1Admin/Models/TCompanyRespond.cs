using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TCompanyRespond
    {
        public long CompanyRespondId { get; set; }
        public long? ResumeSendId { get; set; }
        public string CompanyWindow { get; set; }
        public string CompanyWindowPhone { get; set; }
        public string CompanyWindowEmail { get; set; }
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
