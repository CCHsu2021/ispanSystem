using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TChoiceQuestion
    {
        public string FSubjectId { get; set; }
        public int FQuestionId { get; set; }
        public string FQuestion { get; set; }
        public string FChoiceA { get; set; }
        public string FChoiceB { get; set; }
        public string FChoiceC { get; set; }
        public string FChoiceD { get; set; }
        public string FAnswer { get; set; }
        public int? FLevel { get; set; }
    }
}
