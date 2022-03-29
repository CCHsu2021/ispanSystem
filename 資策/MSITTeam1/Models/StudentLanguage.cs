using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class StudentLanguage
    {
        public long LanguageId { get; set; }
        public string MemberId { get; set; }
        public string LanguageName { get; set; }
        public string Listening { get; set; }
        public string Speaking { get; set; }
        public string Reading { get; set; }
        public string Writing { get; set; }
    }
}
