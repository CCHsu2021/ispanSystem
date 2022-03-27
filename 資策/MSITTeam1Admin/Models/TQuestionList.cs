using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TQuestionList
    {
        public string FSubjectId { get; set; }
        public int FQuestionId { get; set; }
        public string FQuestion { get; set; }
        public byte[] FQuestionImage { get; set; }
        public int? FQuestionTypeId { get; set; }
        public DateTime? FUpdateTime { get; set; }
        public int FLevel { get; set; }
    }
}
