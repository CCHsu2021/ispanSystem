using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class StudentSkill
    {
        public long SkillId { get; set; }
        public string FAccount { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }

        public virtual StudentBasic FAccountNavigation { get; set; }
    }
}
