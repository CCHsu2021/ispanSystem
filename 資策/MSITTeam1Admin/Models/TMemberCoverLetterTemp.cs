using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TMemberCoverLetterTemp
    {
        public long CoverLetterId { get; set; }
        public string FAccount { get; set; }
        public string CoverLetterName { get; set; }
        public string CoverLetterContent { get; set; }
    }
}
