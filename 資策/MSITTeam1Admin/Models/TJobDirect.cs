using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TJobDirect
    {
        public TJobDirect()
        {
            TJobVacancies = new HashSet<TJobVacancy>();
        }

        public int JobListId { get; set; }
        public string FClass { get; set; }
        public string FJobDirect { get; set; }

        public virtual ICollection<TJobVacancy> TJobVacancies { get; set; }
    }
}
