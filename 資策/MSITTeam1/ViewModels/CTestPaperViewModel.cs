using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MSITTeam1.ViewModels
{
    public class CTestPaperViewModel
    {
        public string fSubjectID { get; set; }
        public int fQuestionID { get; set; }
        public string fQuestion { get; set; }
        public string fChoice { get; set; }
        public int fCorrectAnswer { get; set; }
    }
}
