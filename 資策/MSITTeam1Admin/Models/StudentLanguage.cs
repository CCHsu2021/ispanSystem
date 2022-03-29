using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class StudentLanguage
    {
        public long LanguageId { get; set; }
        public string FAccount { get; set; }
        public string LanguageName { get; set; }
        public string Listening { get; set; }
        public string Speaking { get; set; }
        public string Reading { get; set; }
        public string Writing { get; set; }

        public virtual StudentBasic FAccountNavigation { get; set; }
    }
}
