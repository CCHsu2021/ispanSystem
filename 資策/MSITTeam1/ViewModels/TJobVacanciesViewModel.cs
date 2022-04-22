using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class TJobVacanciesViewModel
    {
        private TNewJobVacancy _jobV = null;
        private TCompanyBasic _comB = null;
        private TJobDirect _jobD = null;
        public TJobVacanciesViewModel()
        {
            _jobV = new TNewJobVacancy();
            _comB = new TCompanyBasic();
            _jobD = new TJobDirect();
        }
        public TNewJobVacancy jobV { get { return _jobV; } set { _jobV = value; } }
        public TCompanyBasic comB { get { return _comB; } set { _comB = value; } }
        public TJobDirect jobD { get { return _jobD; } set { _jobD = value; } }
        [DisplayName("公司統編")]
        public string FCompanyTaxid { get { return this.jobV.FCompanyTaxid; } set { jobV.FCompanyTaxid = value; } }
        [DisplayName("職缺名稱")]
        public string FJobName { get { return this.jobV.FJobName; } set { jobV.FJobName = value; } }
        [DisplayName("技術要求")]
        public string FJobSkill { get { return this.jobV.FJobSkill; } set { jobV.FJobSkill = value; } }
        [DisplayName("城市")]
        public string FCity { get { return this.jobV.FCity; } set { jobV.FCity = value; } }
        [DisplayName("地區")]
        public string FDistrict { get { return this.jobV.FDistrict; } set { jobV.FDistrict = value; } }
        [DisplayName("工作地點")]
        public string FWorkAddress { get { return this.jobV.FWorkAddress; } set { jobV.FWorkAddress = value; } }
        [DisplayName("薪水制度")]
        public string FSalaryMode { get { return this.jobV.FSalaryMode; } set { jobV.FSalaryMode = value; } }
        [DisplayName("薪水")]
        public string FSalary { get { return this.jobV.FSalary; } set { jobV.FSalary = value; } }
        [DisplayName("工作型態")]
        public string FEmployeeType { get { return this.jobV.FEmployeeType; } set { jobV.FEmployeeType = value; } }
        [DisplayName("工作時數")]
        public string FWorkHours { get { return this.jobV.FWorkHours; } set { jobV.FWorkHours = value; } }
        [DisplayName("休假制度")]
        public string FLeaveSystem { get { return this.jobV.FLeaveSystem; } set { jobV.FLeaveSystem = value; } }
        [DisplayName("工作經驗")]
        public string FWorkExp { get { return this.jobV.FWorkExp; } set { jobV.FWorkExp = value; } }
        [DisplayName("教育程度")]
        public string FEducation { get { return this.jobV.FEducation; } set { jobV.FEducation = value; } }
        [DisplayName("職缺敘述")]
        public string FOther { get { return this.jobV.FOther; } set { jobV.FOther = value; } }
        [DisplayName("職缺狀態")]
        public string FJobStatus { get { return this.jobV.FJobStatus; } set { jobV.FJobStatus = value; } }
        [DisplayName("職缺類型ID")]
        public int? FJobListId { get { return this.jobV.FJobListId; } set { jobV.FJobListId = value; } }
        [DisplayName("聯絡人")]
        public string FContactPerson { get { return this.jobV.FContactPerson; } set { jobV.FContactPerson = value; } }
        [DisplayName("聯絡電話")]
        public string FContactPhone { get { return this.jobV.FContactPhone; } set { jobV.FContactPhone = value; } }
        [DisplayName("傳真號碼")]
        public string FContactFax { get { return this.jobV.FContactFax; } set { jobV.FContactFax = value; } }
        [DisplayName("電子郵件")]
        public string FContactEmail { get { return this.jobV.FContactEmail; } set { jobV.FContactEmail = value; } }
        [DisplayName("建立時間")]
        public string FCreatTime { get { return this.jobV.FCreatTime; } set { jobV.FCreatTime = value; } }
        [DisplayName("最後修改時間")]
        public DateTime FModifyTime { get { return this.jobV.FModifyTime; } set { jobV.FModifyTime = value; } }
        [DisplayName("需求人數")]
        public string FNeedPerson { get { return this.jobV.FNeedPerson; } set { jobV.FNeedPerson = value; } }
        [DisplayName("公司名稱")]
        public string FCompanyName { get { return this.comB.FName; } set { this.comB.FName = value; } }
        [DisplayName("公司照片")]
        public string FCompanyLogo { get { return this.comB.FLogo; } set { this.comB.FLogo = value; } }
        [DisplayName("職缺類型")]
        public string FJobDirect { get { return this.jobD.FJobDirect; } set { this.jobD.FJobDirect = value; } }


    }
}
