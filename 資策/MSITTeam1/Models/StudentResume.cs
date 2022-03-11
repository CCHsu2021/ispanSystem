using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class StudentResume
    {
        public StudentResume()
        {
            TMemberResumeSends = new HashSet<TMemberResumeSend>();
        }

        public long ResumeId { get; set; }
        public string FAccount { get; set; }
        public int? ResumeStyle { get; set; }
        public string RBasic { get; set; }
        public string RWorkExp { get; set; }
        public string REducation { get; set; }
        public string RSkill { get; set; }
        public string RLanguage { get; set; }
        public string RPortfolio { get; set; }

        public virtual StudentBasic FAccountNavigation { get; set; }
        public virtual ICollection<TMemberResumeSend> TMemberResumeSends { get; set; }
    }
}
