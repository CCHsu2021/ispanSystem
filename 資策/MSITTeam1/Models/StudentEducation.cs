﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class StudentEducation
    {
        public long EducationId { get; set; }
        public string FAccount { get; set; }
        public string GraduateSchool { get; set; }
        public string GraduateDepartment { get; set; }
        public string StudyFrom { get; set; }
        public string StudyTo { get; set; }

        public virtual StudentBasic FAccountNavigation { get; set; }
    }
}
