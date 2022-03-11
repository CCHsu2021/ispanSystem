using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TCityContrast
    {
        public TCityContrast()
        {
            TJobVacancies = new HashSet<TJobVacancy>();
        }

        public int? FPostCode { get; set; }
        public string FCityName { get; set; }
        public string FDistrictName { get; set; }

        public virtual ICollection<TJobVacancy> TJobVacancies { get; set; }
    }
}
