using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class StudentWorkExperience
    {
        public long WorkExperienceId { get; set; }
        public string MemberId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDepartment { get; set; }
        public string JobTitle { get; set; }
        public string EmploymentFrom { get; set; }
        public string EmploymentTo { get; set; }
        public string JobDescription { get; set; }
    }
}
