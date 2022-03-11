using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TQuestionBank
    {
        public string FSubjectId { get; set; }
        public int FQuestionId { get; set; }
        public string FQuestionTypeId { get; set; }
        public DateTime? FUpdateTime { get; set; }
    }
}
