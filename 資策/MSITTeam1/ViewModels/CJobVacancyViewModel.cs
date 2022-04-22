using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class CJobVacancyViewModel
    {
        private TNewJobVacancy _job = null;
        public CJobVacancyViewModel()
        {
            _job = new TNewJobVacancy();
        }
        public TNewJobVacancy job { get { return _job; } set { _job = value; } }
        [DisplayName("統編")]
        public string FCompanyTaxid { get { return this._job.FCompanyTaxid; } set { _job.FCompanyTaxid = value; } }
        [DisplayName("工作名稱")]
        public string FJobName { get { return this._job.FJobName; } set { _job.FJobName = value; } }
        [DisplayName("必備技能")]
        public string FJobSkill { get { return this._job.FJobSkill; } set { _job.FJobSkill = value; } }
        [DisplayName("工作地點")]
        public string FWorkAddress { get { return this._job.FWorkAddress; } set { _job.FWorkAddress = value; } }
        [DisplayName("薪水制度")]
        public string FSalaryMode { get { return this._job.FSalaryMode; } set { _job.FSalaryMode = value; } }
        [DisplayName("薪水")]
        public string FSalary { get { return this._job.FSalary; } set { _job.FSalary = value; } }
        [DisplayName("工作性質")]
        public string FEmployeeType { get { return this._job.FEmployeeType; } set { _job.FEmployeeType = value; } }
        [DisplayName("時數")]
        public string FWorkHours { get { return this._job.FWorkHours; } set { _job.FWorkHours=value; } }
        [DisplayName("休假制度")]
        public string FLeaveSystem { get { return this._job.FLeaveSystem; } set { _job.FLeaveSystem = value; } }
        [DisplayName("工作經歷")]
        public string FWorkExp { get { return this._job.FWorkExp; } set { _job.FWorkExp = value; } }
        [DisplayName("教育程度")]
        public string FEducation { get { return this._job.FEducation; } set { _job.FEducation = value; } }
        [DisplayName("備註")]
        public string FOther { get { return this._job.FOther; } set { _job.FOther = value; } }
        [DisplayName("職缺狀態")]
        public string FJobStatus { get { return this._job.FJobStatus; } set { _job.FJobStatus = value; } }
        public int? FJobListId { get { return this._job.FJobListId; } set { _job.FJobListId = value; } }
        [DisplayName("聯繫人")]
        public string FContactPerson { get { return this._job.FContactPerson; } set { _job.FContactPerson = value; } }
        [DisplayName("聯繫人電話")]
        public string FContactPhone { get { return this._job.FContactPhone; } set { _job.FContactPhone = value; } }
        [DisplayName("聯繫人傳真")]
        public string FContactFax { get { return this._job.FContactFax; } set { _job.FContactFax = value; } }
        [DisplayName("聯繫人信箱")]
        public string FContactEmail { get { return this._job.FContactEmail; } set { _job.FContactEmail = value; } }
        [DisplayName("新增時間")]
        public string FCreatTime { get { return this._job.FCreatTime; } set { _job.FCreatTime = value; } }
        [DisplayName("最後編輯時間")]
        public DateTime FModifyTime { get { return this._job.FModifyTime; } set { _job.FModifyTime = value; } }
        public string FCity { get { return this._job.FCity; } set { _job.FCity = value; } }
        public string FDistrict { get { return this._job.FDistrict; } set { _job.FDistrict = value; } }
        public string FNeedPerson { get { return this._job.FNeedPerson; } set { _job.FNeedPerson = value; } }
    }
}
