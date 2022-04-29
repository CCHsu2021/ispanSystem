using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TNewJobVacancy
    {
        public string FCompanyTaxid { get; set; }
        public string FJobName { get; set; }
        public string FJobSkill { get; set; }
        public string FCity { get; set; }
        public string FDistrict { get; set; }
        public string FWorkAddress { get; set; }
        public string FSalaryMode { get; set; }
        public string FSalaryMin { get; set; }
        public string FSalaryMax { get; set; }
        public string FEmployeeType { get; set; }
        public string FWorkHours { get; set; }
        public string FLeaveSystem { get; set; }
        public string FWorkExp { get; set; }
        public string FEducation { get; set; }
        public string FOther { get; set; }
        public string FJobStatus { get; set; }
        public int? FJobListId { get; set; }
        public string FContactPerson { get; set; }
        public string FContactPhone { get; set; }
        public string FContactFax { get; set; }
        public string FContactEmail { get; set; }
        public string FCreatTime { get; set; }
        public DateTime FModifyTime { get; set; }
        public string FNeedPerson { get; set; }
    }
}
