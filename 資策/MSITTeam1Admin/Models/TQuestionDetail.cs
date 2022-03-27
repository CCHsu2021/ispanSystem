using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TQuestionDetail
    {
        public string FSubjectId { get; set; }
        public int FQuestionId { get; set; }
        public string FChoice { get; set; }
        public byte[] FImage { get; set; }
        public int FCorrectAnswer { get; set; }
    }
}
