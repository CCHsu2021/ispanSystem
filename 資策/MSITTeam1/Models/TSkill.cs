using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TSkill
    {
        public int FSkillId { get; set; }
        public string FSkillName { get; set; }
        public long FJobId { get; set; }

        public virtual TJobVacancy FJob { get; set; }
    }
}
