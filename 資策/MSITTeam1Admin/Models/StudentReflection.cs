using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class StudentReflection
    {
        public long ReflectionId { get; set; }
        public string MemberId { get; set; }
        public string ReflectionTitle { get; set; }
        public string ReflectionContent { get; set; }
    }
}
