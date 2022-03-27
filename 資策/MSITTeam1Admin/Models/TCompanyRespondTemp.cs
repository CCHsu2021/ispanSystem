using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TCompanyRespondTemp
    {
        public long TempId { get; set; }
        public int CompanyId { get; set; }
        public string TempName { get; set; }
        public string TempContent { get; set; }
    }
}
