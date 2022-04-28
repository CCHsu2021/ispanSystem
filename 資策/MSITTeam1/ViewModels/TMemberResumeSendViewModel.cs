using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class TMemberResumeSendViewModel
    {
        private TMemberResumeSend _memRS = null;
        public TMemberResumeSendViewModel()
        {
            _memRS = new TMemberResumeSend();
        }

        public TMemberResumeSend memRS { get { return _memRS; } set { _memRS = value; } }
        [DisplayName("求職單ID")]
        public string ResumeSendId { get { return this.memRS.ResumeSendId; } set { memRS.ResumeSendId= value; } }
        [DisplayName("履歷ID")]
        public long ResumeId { get { return this.memRS.ResumeId; } set { memRS.ResumeId= value; } }
        [DisplayName("學員帳號")]
        public string MemberId { get { return this.memRS.MemberId; } set { memRS.MemberId = value; } }
        [DisplayName("公司統編")]
        public string CompanyTaxid { get { return this.memRS.CompanyTaxid; } set { memRS.CompanyTaxid= value; } }
        [DisplayName("職缺名稱")]
        public string JobName { get { return this.memRS.JobName; } set { memRS.JobName= value; } }
        [DisplayName("聯絡電話")]
        public string ContactPhone { get { return this.memRS.ContactPhone; } set { memRS.ContactPhone= value; } }
        [DisplayName("聯絡信箱")]
        public string ContactEmail { get { return this.memRS.ContactEmail; } set { memRS.ContactEmail = value; } }
        [DisplayName("求職單狀態")]
        public string ComReadOrNot { get { return this.memRS.ComReadOrNot; } set { memRS.ComReadOrNot= value; } }
        [DisplayName("聯絡時間")]
        public string TimeToContact { get { return this.memRS.TimeToContact; } set { memRS.TimeToContact = value; } }
        [DisplayName("求職信內容")]
        public string CoverLetter { get { return this.memRS.CoverLetter; } set { memRS.CoverLetter= value; } }
        [DisplayName("建立時間")]
        public string CreatTime { get { return this.memRS.CreatTime; } set { memRS.CreatTime = value; } }
        [DisplayName("最後修改時間")]
        public string ModifyTime { get { return this.memRS.ModifyTime; } set { memRS.ModifyTime= value; } }

        public virtual ICollection<TCompanyRespond> TCompanyResponds { get { return this.memRS.TCompanyResponds; } set { memRS.TCompanyResponds = value; } }

    }
}
