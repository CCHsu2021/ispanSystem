using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;


namespace MSITTeam1.ViewModels
{
    public class TCompanyRespondViewModel
    {
        private TCompanyRespond _comR = null;
        public TCompanyRespondViewModel()
        {
            _comR = new TCompanyRespond();
        }
        public TCompanyRespond comR { get { return _comR; } set { _comR = value; } }
        [DisplayName("公司回應ID")]
        public long CompanyRespondId { get { return this.comR.CompanyRespondId; } set { this.comR.CompanyRespondId = value; } }
        [DisplayName("求職單ID")]
        public string ResumeSendId { get { return this.comR.ResumeSendId; } set { this.comR.ResumeSendId = value; } }
        [DisplayName("聯絡人")]
        public string ContactPerson { get { return this.comR.ContactPerson; } set { this.comR.ContactPerson= value; } }
        [DisplayName("聯絡人電話")]
        public string ContactPersonPhone { get { return this.comR.ContactPersonPhone; } set { this.comR.ContactPersonPhone= value; } }
        [DisplayName("聯絡人信箱")]
        public string ContactPersonEmail { get { return this.comR.ContactPersonEmail; } set { this.comR.ContactPersonEmail = value; } }
        [DisplayName("傳真號碼")]
        public string ContactPersonFax { get { return this.comR.ContactPersonFax; } set { this.comR.ContactPersonFax= value; } }
        [DisplayName("面試狀態")]
        public string InterviewState { get { return this.comR.InterviewState; } set { this.comR.InterviewState = value; } }
        [DisplayName("面試時間")]
        public string InterviewTime { get { return this.comR.InterviewTime; } set { this.comR.InterviewTime= value; } }
        [DisplayName("面試地點")]
        public string InterviewAddress { get { return this.comR.InterviewAddress; } set { this.comR.InterviewAddress = value; } }
        [DisplayName("幾天內回應")]
        public string StudentRespondTime { get { return this.comR.StudentRespondTime; } set { this.comR.StudentRespondTime = value; } }
        [DisplayName("邀約面試信內容")]
        public string InterviewContent { get { return this.comR.InterviewContent; } set { this.comR.InterviewContent = value; } }
        [DisplayName("建立時間")]
        public string CreatTime { get { return this.comR.CreatTime; } set { this.comR.CreatTime = value; } }
        [DisplayName("修改時間")]
        public string ModifyTime { get { return this.comR.ModifyTime; } set { this.comR.ModifyTime = value; } }
        [DisplayName("工作名稱")]
        public string JobName { get; set; }
    }
}
