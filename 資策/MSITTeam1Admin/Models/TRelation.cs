using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TRelation
    {
        public string CompanyTaxid { get; set; }
        public string FAccountEmail { get; set; }
        public string DepartmentName { get; set; }
        public string JobPosition { get; set; }
        public string Updater { get; set; }
        public DateTime? UpdateDatetime { get; set; }
    }
}
