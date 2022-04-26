using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class CCompanyBasicWithPhotoViewModelcs
    {
        private TCompanyBasic _combasic = null;
        private TPhoto _photo = null;
        public CCompanyBasicWithPhotoViewModelcs()
        {
            _combasic = new TCompanyBasic();
            _photo = new TPhoto();
        }
        public TCompanyBasic combasic { get { return _combasic; } set { _combasic = value; } }
        public TPhoto photo { get { return _photo; } set { _photo = value; } }
    }
}
