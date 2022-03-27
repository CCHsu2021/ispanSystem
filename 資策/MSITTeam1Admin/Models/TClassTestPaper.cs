using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class TClassTestPaper
    {
        public int TestPaperId { get; set; }
        public int TopicId { get; set; }
        public string Topic { get; set; }
        public string ChoseAnswer { get; set; }
        public string TopicAnswer { get; set; }
        public string ClassMember { get; set; }
    }
}
