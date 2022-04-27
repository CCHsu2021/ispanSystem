using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class SPointRecordViewModel
    {
        private TStudentPoint _stPoint = null;
        public SPointRecordViewModel()
        {
            _stPoint = new TStudentPoint();
        }
        public TStudentPoint stPoint { get { return _stPoint; } set { _stPoint = value; } }
        public int pointUsageId  { get { return stPoint.PointUsageId; } set { stPoint.PointUsageId = value; } }
        public string MemberId  { get { return stPoint.MemberId; } set { stPoint.MemberId = value; } }
        public DateTime? PointDate  { get { return stPoint.PointDate; } set { stPoint.PointDate = value; } }
        public string PointType { get { return stPoint.PointType; } set { stPoint.PointType = value; } }
        public string PointDes { get { return stPoint.PointDescription; } set { stPoint.PointDescription = value; } }
        public string PointRecord { get { return stPoint.PointRecord; } set { stPoint.PointRecord = value; } }
        public string OrderId { get { return stPoint.OrderId; } set { stPoint.OrderId = value; } }
     
    }
}
