using Microsoft.AspNetCore.Http;
using MSITTeam1.Models;
using System.ComponentModel;

namespace MSITTeam1.ViewModels
{
    public class CStudentResumeViewModel
    {
        private StudentBasic _student = null;
        private StudentWorkExperience _workExperience = null;
        public IFormFile photo { get; set; }
        public CStudentResumeViewModel()
        {
            _student = new StudentBasic();
            _workExperience = new StudentWorkExperience();
        }
        public StudentBasic student
        {
            get { return _student; }
            set { _student = value; }
        }
        public StudentWorkExperience workExperience
        {
            get { return _workExperience; }
            set { _workExperience = value; }
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
        
        public string fCity
        {
            get { return this.student.FCity; }
            set { this.student.FCity = value; }
        }
        public string fDistrict
        {
            get { return this.student.FDistrict; }
            set { this.student.FDistrict = value; }
        }
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
        [DisplayName("")]
        public long WorkExperienceId
        {
            get { return this.workExperience.WorkExperienceId; }
            set { this.workExperience.WorkExperienceId = value; }
        }
        public string WorkMemberId
        {
            get { return this.workExperience.MemberId; }
            set { this.workExperience.MemberId = value; }
        }
        [DisplayName("公司名稱:")]
        public string CompanyName
        {
            get { return this.workExperience.CompanyName; }
            set { this.workExperience.CompanyName = value; }
        }
        [DisplayName("工作部門:")]
        public string CompanyDepartment
        {
            get { return this.workExperience.CompanyDepartment; }
            set { this.workExperience.CompanyDepartment = value; }
        }
        [DisplayName("職位名稱:")]
        public string JobTitle
        {
            get { return this.workExperience.JobTitle; }
            set { this.workExperience.JobTitle = value; }
        }
        [DisplayName("開始時間:")]
        public string EmploymentFrom
        {
            get { return this.workExperience.EmploymentFrom; }
            set { this.workExperience.EmploymentFrom = value; }
        }
        [DisplayName("結束時間:")]
        public string EmploymentTo
        {
            get { return this.workExperience.EmploymentTo; }
            set { this.workExperience.EmploymentTo = value; }
        }
        [DisplayName("內容描述:")]
        public string JobDescription
        {
            get { return this.workExperience.JobDescription; }
            set { this.workExperience.JobDescription = value; }
        }
    }
}
