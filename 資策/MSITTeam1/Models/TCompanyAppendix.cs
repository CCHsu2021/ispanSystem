using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TCompanyAppendix
    {
        public long AppendixId { get; set; }
        public string CompanyId { get; set; }
        public string AppendixName { get; set; }
        public string AppendixContent { get; set; }
    }
}
