using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TQuestionDetail
    {
        public int FSn { get; set; }
        public string FSubjectId { get; set; }
        public int FQuestionId { get; set; }
        public string FChoice { get; set; }
        public byte[] FImage { get; set; }
        public int FCorrectAnswer { get; set; }
    }
}
