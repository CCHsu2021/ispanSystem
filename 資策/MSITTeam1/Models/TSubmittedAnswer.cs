﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TSubmittedAnswer
    {
        public int FSn { get; set; }
        public string FMemberAccount { get; set; }
        public string FSubjectId { get; set; }
        public string FQuestionId { get; set; }
        public string FSubmitAnswer { get; set; }
        public string FCorrectAnswer { get; set; }
    }
}
