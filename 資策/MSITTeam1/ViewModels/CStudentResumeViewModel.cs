using Microsoft.AspNetCore.Http;
using MSITTeam1.Models;
using System.ComponentModel;

namespace MSITTeam1.ViewModels
{
    public class CStudentResumeViewModel
    {
        private StudentBasic _student = null;
        public IFormFile photo { get; set; }
        public CStudentResumeViewModel()
        {
            _student = new StudentBasic();
        }
        public StudentBasic student
        {
            get { return _student; }
            set { _student = value; }
        }
        public string MemberId
        {
            get { return this.student.MemberId; }
            set { this.student.MemberId = value; }
        }
        [DisplayName("姓名:")]
        public string fName
        {
            get { return this.student.Name; }
            set { this.student.Name = value; }
        }
        [DisplayName("性別:")]
        public string fGender
        {
            get { return this.student.Gender; }
            set { this.student.Gender = value; }
        }
        [DisplayName("生日:")]
        public string fBirthDate
        {
            get { return this.student.BirthDate; }
            set { this.student.BirthDate = value; }
        }
        [DisplayName("電子信箱:")]
        public string fEmail
        {
            get { return this.student.Email; }
            set { this.student.Email = value; }
        }
        [DisplayName("手機:")]
        public string fPhone
        {
            get { return this.student.Phone; }
            set { this.student.Phone = value; }
        }
        //public string fCity { get; set; }
        //public string fDistrict { get; set; }
        [DisplayName("地址:")]
        public string fAddress
        {
            get { return this.student.ContactAddress; }
            set { this.student.ContactAddress = value; }
        }
        [DisplayName("自我介紹:")]
        public string fAutobiography
        {
            get { return this.student.Autobiography; }
            set { this.student.Autobiography = value; }
        }
        [DisplayName("學員照片:")]
        public string fPortrait
        {
            get { return this.student.Portrait; }
            set { this.student.Portrait = value; }
        }

        /// 工作經歷
        [DisplayName("公司名稱:")]
        public string CompanyName{ get; set; }
        [DisplayName("工作部門:")]
        public string CompanyDepartment { get; set; }
        [DisplayName("職位名稱:")]
        public string JobTitle { get; set; }
        [DisplayName("開始時間:")]
        public string EmploymentFrom { get; set; }
        [DisplayName("結束時間:")]
        public string EmploymentTo { get; set; }
        [DisplayName("內容描述:")]
        public string JobDescription { get; set; }
    }
}
