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
        public string fAccount
        {
            get { return this.student.FAccount; }
            set { this.student.FAccount = value; }
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
    }
}
