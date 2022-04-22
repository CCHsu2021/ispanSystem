using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TJobVacancy
    {
        public TJobVacancy()
        {
            TSkills = new HashSet<TSkill>();
        }

        public long FJobId { get; set; }
        public int? FJoblistId { get; set; }
        public int FCompanyId { get; set; }
        public string FAccount { get; set; }
        public string FSalaryMode { get; set; }
        public string FSalary { get; set; }
        public string FEmployeesType { get; set; }
        public string FWorkAddress { get; set; }
        public int? FPostCode { get; set; }
        public string FCity { get; set; }
        public string FDistrict { get; set; }
        public string FWorkHours { get; set; }
        public string FLeaveSystem { get; set; }
        public string FWorkExp { get; set; }
        public string FEducation { get; set; }
        public string FOther { get; set; }
        public string FNeedPerson { get; set; }
        public string FJobName { get; set; }
        public string FLanguage { get; set; }
        public string FContactPerson { get; set; }
        public string FContactPhone { get; set; }
        public string FFax { get; set; }
        public string FEmail { get; set; }

        public virtual TCityContrast F { get; set; }
        public virtual TCompanyBasic FAccountNavigation { get; set; }
        public virtual TJobDirect FJoblist { get; set; }
        public virtual ICollection<TSkill> TSkills { get; set; }
    }
}
