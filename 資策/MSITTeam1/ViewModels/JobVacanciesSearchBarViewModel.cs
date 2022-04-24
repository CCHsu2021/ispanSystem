using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class JobVacanciesSearchBarViewModel
    {
        public string txtSearchText { get; set; }
        public int ddlJobListId { get; set; }
        public string ddlCity { get; set; }
    }
}
