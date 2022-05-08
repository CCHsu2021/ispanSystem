using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class ClassOrderDetailViewModel
    {
        private TClassOrderDetail _classOrderDetail = null;
        public ClassOrderDetailViewModel()
        {
            _classOrderDetail = new TClassOrderDetail();
        }
        public TClassOrderDetail classOrderDetail
        {
            get { return _classOrderDetail; }
            set { _classOrderDetail = value; }
        }
        public string OrderId
        {
            get { return this.classOrderDetail.OrderId; }
            set { this.classOrderDetail.OrderId = value; }
        }
        public string ClassExponent
        {
            get { return this.classOrderDetail.ClassExponent; }
            set { this.classOrderDetail.ClassExponent = value; }
        }
        public string MemberId
        {
            get { return this.classOrderDetail.MemberId; }
            set { this.classOrderDetail.MemberId = value; }
        }
        public string DepartmentName
        {
            get { return this.classOrderDetail.DepartmentName; }
            set { this.classOrderDetail.DepartmentName = value; }
        }
        public string StaffName
        {
            get { return this.classOrderDetail.StaffName; }
            set { this.classOrderDetail.StaffName = value; }
        }
        public string StaffEmail
        {
            get { return this.classOrderDetail.StaffEmail; }
            set { this.classOrderDetail.StaffEmail = value; }
        }
        public int? Price
        {
            get { return this.classOrderDetail.Price; }
            set { this.classOrderDetail.Price = value; }
        }
        public int? Qty
        {
            get { return this.classOrderDetail.Qty; }
            set { this.classOrderDetail.Qty = value; }
        }
    }
}
