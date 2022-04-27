using MSITTeam1Admin.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1Admin.ViewModels
{
    public class backGrade
    {
        public IEnumerable<TClassGrade> TClassGrade{ get; set; }
        public IEnumerable<TSkillGrade> TSkillGrade {get; set; }
    }
}
