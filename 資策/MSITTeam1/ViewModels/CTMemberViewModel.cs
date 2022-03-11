using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class CTMemberViewModel
    {
        private TMember _TMember = null;
        
        public CTMemberViewModel()
        {
            _TMember = new TMember();
        }
        public TMember member
        {
            get { return _TMember; }
            set { _TMember = value; }
        }
        public string FAccount { get { return this.FAccount; } set { this.FAccount = value; } }
        public byte[] FPassword { get { return this.FPassword; } set { this.FPassword = value; } }
        public byte[] FSalt { get { return this.FSalt; } set { this.FSalt = value; } }
        public int? FMemberType { get { return this.FMemberType; } set { this.FMemberType = value; } }
    }
}
