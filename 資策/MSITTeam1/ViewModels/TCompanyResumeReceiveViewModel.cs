using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class TCompanyResumeReceiveViewModel
    {
        private TMemberResumeSend _memRS = null;
        private TCompanyBasic _comB = null;
        private StudentBasic _stuB = null;
        public TCompanyResumeReceiveViewModel()
        {
            _memRS = new TMemberResumeSend();
            _comB = new TCompanyBasic();
            _stuB = new StudentBasic();
        }

        public TMemberResumeSend memRS { get { return _memRS; } set { _memRS = value; } }
        public TCompanyBasic comB { get { return _comB; } set { _comB = value; } }
        public StudentBasic stuB { get { return _stuB; } set { _stuB = value; } }
        [DisplayName("求職單ID")]
        public string ResumeSendId { get { return this.memRS.ResumeSendId; } set { memRS.ResumeSendId = value; } }
        [DisplayName("職缺ID")]
        public int JobId { get { return this.memRS.JobId; } set { memRS.JobId = value; } }
        [DisplayName("履歷ID")]
        public long ResumeId { get { return this.memRS.ResumeId; } set { memRS.ResumeId = value; } }
        [DisplayName("學員帳號")]
        public string MemberId { get { return this.memRS.MemberId; } set { memRS.MemberId = value; } }
        [DisplayName("公司統編")]
        public string CompanyTaxid { get { return this.memRS.CompanyTaxid; } set { memRS.CompanyTaxid = value; } }
        [DisplayName("職缺名稱")]
        public string JobName { get { return this.memRS.JobName; } set { memRS.JobName = value; } }
        [DisplayName("聯絡電話")]
        public string ContactPhone { get { return this.memRS.ContactPhone; } set { memRS.ContactPhone = value; } }
        [DisplayName("聯絡信箱")]
        [EmailAddress]
        public string ContactEmail { get { return this.memRS.ContactEmail; } set { memRS.ContactEmail = value; } }
        [DisplayName("求職單狀態")]
        public string ComReadOrNot { get { return this.memRS.ComReadOrNot; } set { memRS.ComReadOrNot = value; } }
        [DisplayName("聯絡時間")]
        public string TimeToContact { get { return this.memRS.TimeToContact; } set { memRS.TimeToContact = value; } }
        [DisplayName("求職信內容")]
        [MinLength(20)]
        [MaxLength(500)]
        public string CoverLetter { get { return this.memRS.CoverLetter; } set { memRS.CoverLetter = value; } }
        [DisplayName("建立時間")]
        public string CreatTime { get { return this.memRS.CreatTime; } set { memRS.CreatTime = value; } }
        [DisplayName("最後修改時間")]
        public string ModifyTime { get { return this.memRS.ModifyTime; } set { memRS.ModifyTime = value; } }
        [DisplayName("公司名稱")]
        public string FCompanyName { get { return this._comB.FName; } set { _comB.FName = value; } }
        [DisplayName("學員名稱")]
        public string FStudentName { get { return this._stuB.Name; } set { _stuB.Name = value; } }


        //public virtual ICollection<TCompanyRespond> TCompanyResponds { get { return this.memRS.TCompanyResponds; } set { memRS.TCompanyResponds = value; } }

    }
}

