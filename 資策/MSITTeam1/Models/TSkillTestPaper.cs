using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TSkillTestPaper
    {
        public string TestPaper { get; set; }
        public int TopicId { get; set; }
        public string Topic { get; set; }
        public string TopicAnswer { get; set; }
        public string SkillJobClass { get; set; }
    }
}
