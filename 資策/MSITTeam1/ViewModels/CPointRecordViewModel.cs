using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class CPointRecordViewModel
    {
        private TCompanyPoint _ctPoint = null;
        private TMemberLevel _level = null;
        public CPointRecordViewModel()
        {
            _ctPoint = new TCompanyPoint();
            _level = new TMemberLevel();
        }
        public TCompanyPoint ctPoint { get { return _ctPoint; } set { _ctPoint = value; } }
        public int pointUsageId  { get { return _ctPoint.PointUsageId; } set { _ctPoint.PointUsageId = value; } }
        public DateTime PointDate  { get { return _ctPoint.PointDate; } set { _ctPoint.PointDate = value; } }
        public string PointType { get { return _ctPoint.PointType; } set { _ctPoint.PointType = value; } }
        public string PointDes { get { return _ctPoint.PointDescription; } set { _ctPoint.PointDescription = value; } }
        public int? PointRecord { get { return _ctPoint.PointRecord; } set { _ctPoint.PointRecord = value; } }
        public string OrderId { get { return _ctPoint.OrderId; } set { _ctPoint.OrderId = value; } }
        public string TitleName { get { return _level.Title; } set { _level.Title = value; } }
        public string CompanyTAXID { get { return _ctPoint.CompanyTaxid; } set { _ctPoint.CompanyTaxid = value; } }


    }
}
