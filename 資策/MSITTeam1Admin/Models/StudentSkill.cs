using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class StudentSkill
    {
        public long SkillId { get; set; }
        public string MemberId { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
    }
}
