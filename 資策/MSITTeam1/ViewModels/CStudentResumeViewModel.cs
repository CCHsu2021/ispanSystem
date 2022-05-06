using Microsoft.AspNetCore.Http;
using MSITTeam1.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MSITTeam1.ViewModels
{
    public class CStudentResumeViewModel
    {
        private StudentBasic _student = null;
        private StudentWorkExperience _workExperience = null;
        private StudentEducation _education = null;
        private StudentLanguage _language = null;
        private StudentSkill _skill = null;
        private StudentPortfolio _portfolio = null;
        private StudentResume _resume = null;
        public IFormFile photo { get; set; }
        public CStudentResumeViewModel()
        {
            _student = new StudentBasic();
            _workExperience = new StudentWorkExperience();
            _education = new StudentEducation();
            _language = new StudentLanguage();
            _skill = new StudentSkill();
            _portfolio = new StudentPortfolio();
            _resume = new StudentResume();
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
        public StudentEducation education
        {
            get { return _education; }
            set { _education = value; }
        }
        public StudentLanguage language
        {
            get { return _language; }
            set { _language = value; }
        }
        public StudentSkill skill
        {
            get { return _skill; }
            set { _skill = value; }
        }
        public StudentPortfolio portfolio
        {
            get { return _portfolio; }
            set { _portfolio = value; }
        }
        public StudentResume resume
        {
            get { return _resume; }
            set { _resume = value; }
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
        public enum Gender
        {
            男生,
            女生,
            未指定
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

        // 工作經歷
        public int WorkCount { get; set; }
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

        //學歷
        [DisplayName("")]
        public long EducationId
        {
            get { return this.education.EducationId; }
            set { this.education.EducationId = value; }
        }
        public string EduMemberId
        {
            get { return this.education.MemberId; }
            set { this.education.MemberId = value; }
        }
        [DisplayName("畢業學校:")]
        public string GraduateSchool
        {
            get { return this.education.GraduateSchool; }
            set { this.education.GraduateSchool = value; }
        }

        [DisplayName("畢業系所:")]
        public string GraduateDepartment
        {
            get { return this.education.GraduateDepartment; }
            set { this.education.GraduateDepartment = value; }
        }
        [DisplayName("就讀時間:")]
        public string StudyFrom
        {
            get { return this.education.StudyFrom; }
            set { this.education.StudyFrom = value; }
        }
        [DisplayName("畢業時間:")]
        public string StudyTo
        {
            get { return this.education.StudyTo; }
            set { this.education.StudyTo = value; }
        }

        //語言
        [DisplayName("")]
        public long LanguageId
        {
            get { return this.language.LanguageId; }
            set { this.language.LanguageId = value; }
        }
        public string LanMemberId
        {
            get { return this.language.MemberId; }
            set { this.language.MemberId = value; }
        }
        [DisplayName("語言名稱:")]
        public string LanguageName
        {
            get { return this.language.LanguageName; }
            set { this.language.LanguageName = value; }
        }
        [DisplayName("聽力程度:")]
        public string Listening
        {
            get { return this.language.Listening; }
            set { this.language.Listening = value; }
        }
        [DisplayName("口說程度:")]
        public string Speaking
        {
            get { return this.language.Speaking; }
            set { this.language.Speaking = value; }
        }
        [DisplayName("閱讀程度:")]
        public string Reading
        {
            get { return this.language.Reading; }
            set { this.language.Reading= value; }
        }
        [DisplayName("寫作程度:")]
        public string Writing
        {
            get { return this.language.Writing; }
            set { this.language.Writing = value; }
        }
        public enum lanLevel
        {
            初階,
            中等,
            高階,
            母語
        }

        //技能
        [DisplayName("")]
        public long SkillId
        {
            get { return this.skill.SkillId; }
            set { this.skill.SkillId = value; }
        }

        public string SkillMemberId
        {
            get { return this.skill.MemberId; }
            set { this.skill.MemberId = value; }
        }
        [DisplayName("技能名稱:")]
        public string SkillName
        {
            get { return this.skill.SkillName; }
            set { this.skill.SkillName = value; }
        }
        [DisplayName("技能說明:")]
        public string SkillDescription
        {
            get { return this.skill.SkillDescription; }
            set { this.skill.SkillDescription = value; }
        }
        //作品
        [DisplayName("")]
        public long PortId
        {
            get { return this.portfolio.PortfolioId; }
            set { this.portfolio.PortfolioId = value; }
        }
        public string PortMemberId
        {
            get { return this.portfolio.MemberId; }
            set { this.portfolio.MemberId = value; }
        }
        [DisplayName("作品名稱:")]
        public string PortfolioTitle
        {
            get { return this.portfolio.PortfolioTitle; }
            set { this.portfolio.PortfolioTitle = value; }
        }
        [DisplayName("作品介紹:")]
        public string PortfolioDescription
        {
            get { return this.portfolio.PortfolioDescription; }
            set { this.portfolio.PortfolioDescription = value; }
        }
        [DisplayName("作品網址:")]
        public string PortfolioURL
        {
            get { return this.portfolio.PortfolioUrl; }
            set { this.portfolio.PortfolioUrl = value; }
        }

        //
        public long RusumeId
        {
            get { return this.resume.ResumeId; }
            set { this.resume.ResumeId = value; }
        }
        public string ResumeMemberId
        {
            get { return this.resume.MemberId; }
            set { this.resume.MemberId = value; }
        }
        [DisplayName("履歷名稱:")]
        public string ResumeName
        {
            get { return this.resume.ResumeName; }
            set { this.resume.ResumeName = value; }
        }
        //public byte[] FileData
        //{
        //    get { return this.resume.re; }
        //    set { this.student.BirthDate = value; }
        //}
    }
}
