using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class LearnMap
    {
        public IEnumerable<TStudioInformation> TStudioInformationleft { get; set; }
        public IEnumerable<TStudioInformation> TStudioInformationright { get; set; }

    }
}
