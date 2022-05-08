using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class ResumeSendAndCompanyRespondViewModel
    {
        private TCompanyRespond _comR = null;
        private TMemberResumeSend _memRS = null;
        public ResumeSendAndCompanyRespondViewModel()
        {
            _comR = new TCompanyRespond();
            _memRS = new TMemberResumeSend();
        }

        public TCompanyRespond comR { get { return _comR; } set { _comR = value; } }
        public TMemberResumeSend memRS { get { return _memRS; } set { _memRS = value; } }



        [DisplayName("公司回應單ID")]
        public string CompanyRespondId { get { return this.comR.CompanyRespondId; } set { this.comR.CompanyRespondId = value; } }
        [DisplayName("求職單ID")]
        public string ResumeSendId { get { return this.comR.ResumeSendId; } set { this.comR.ResumeSendId = value; } }
        [DisplayName("聯絡人")]
        public string ContactPerson { get { return this.comR.ContactPerson; } set { this.comR.ContactPerson = value; } }
        [DisplayName("聯絡人電話")]
        public string ContactPersonPhone { get { return this.comR.ContactPersonPhone; } set { this.comR.ContactPersonPhone = value; } }
        [DisplayName("聯絡人信箱")]
        public string ContactPersonEmail { get { return this.comR.ContactPersonEmail; } set { this.comR.ContactPersonEmail = value; } }
        [DisplayName("傳真號碼")]
        public string ContactPersonFax { get { return this.comR.ContactPersonFax; } set { this.comR.ContactPersonFax = value; } }
        [DisplayName("面試狀態")]
        public string InterviewState { get { return this.comR.InterviewState; } set { this.comR.InterviewState = value; } }
        [DisplayName("面試時間")]
        public string InterviewTime { get { return this.comR.InterviewTime; } set { this.comR.InterviewTime = value; } }
        [DisplayName("面試地點")]
        public string InterviewAddress { get { return this.comR.InterviewAddress; } set { this.comR.InterviewAddress = value; } }
        [DisplayName("希望回應時間")]
        public string StudentRespondTime { get { return this.comR.StudentRespondTime; } set { this.comR.StudentRespondTime = value; } }
        [DisplayName("面試內容")]
        public string InterviewContent { get { return this.comR.InterviewContent; } set { this.comR.InterviewContent = value; } }
        [DisplayName("公司回應單建立時間")]
        public string CreatTime { get { return this.comR.CreatTime; } set { this.comR.CreatTime = value; } }
        [DisplayName("公司回應單修改時間")]
        public string ModifyTime { get { return this.comR.ModifyTime; } set { this.comR.ModifyTime = value; } }


        //[DisplayName("求職單ID")]
        //public string ResumeSendId { get { return this.memRS.ResumeSendId; } set { memRS.ResumeSendId = value; } }
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
        [DisplayName("可聯絡時間")]
        public string TimeToContact { get { return this.memRS.TimeToContact; } set { memRS.TimeToContact = value; } }
        [DisplayName("求職信內容")]
        [MinLength(20)]
        [MaxLength(500)]
        public string CoverLetter { get { return this.memRS.CoverLetter; } set { memRS.CoverLetter = value; } }
        [DisplayName("求職單建立時間")]
        public string ResumeSendCreatTime { get { return this.memRS.CreatTime; } set { memRS.CreatTime = value; } }
        [DisplayName("求職單修改時間")]
        public string ResumeSendModifyTime { get { return this.memRS.ModifyTime; } set { memRS.ModifyTime = value; } }
        [DisplayName("學員姓名")]
        public string StudentName { get; set; }
        public string CompanyName { get; set; }
    }
}
