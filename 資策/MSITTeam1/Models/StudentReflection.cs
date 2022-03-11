using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class StudentReflection
    {
        public long ReflectionId { get; set; }
        public string FAccount { get; set; }
        public string ReflectionTitle { get; set; }
        public string ReflectionContent { get; set; }

        public virtual StudentBasic FAccountNavigation { get; set; }
    }
}
