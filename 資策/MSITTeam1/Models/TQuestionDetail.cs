using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TQuestionDetail
    {
        public string FSubjectId { get; set; }
        public string FQuestionId { get; set; }
        public string FDetail { get; set; }
        public byte[] FImage { get; set; }
        public int FCorrectAnswer { get; set; }
    }
}
