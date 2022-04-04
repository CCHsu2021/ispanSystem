using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TCompanyContactPerson
    {
        public int FId { get; set; }
        public string FCompanyTaxid { get; set; }
        public string FDepartmentName { get; set; }
        public string FContactPerson { get; set; }
        public string FContactPhone { get; set; }
        public string FContactFax { get; set; }
        public string FStatus { get; set; }
        public string FAccount { get; set; }
        public string FPassword { get; set; }
    }
}
