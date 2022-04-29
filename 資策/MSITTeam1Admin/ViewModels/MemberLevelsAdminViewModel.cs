using Microsoft.AspNetCore.Http;
using MSITTeam1Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1Admin.ViewModels
{
    public class MemberLevelsAdminViewModel
    {
        private TMemberLevel _memLevel = null;
        public MemberLevelsAdminViewModel()
        {
            _memLevel = new TMemberLevel();
        }
        public TMemberLevel memLevel
        {
            get { return _memLevel; }
            set { _memLevel = value; }
        }
        public int fLevel { get { return this.memLevel.FLevel; } set { this.memLevel.FLevel = value; } }
        public string Title
        {
            get { return this.memLevel.Title; }
            set { this.memLevel.Title = value; }
        }
        public double? BonusParcent
        {
            get { return this.memLevel.BonusPercent; }
            set { this.memLevel.BonusPercent = value; }
        }
    }
}
