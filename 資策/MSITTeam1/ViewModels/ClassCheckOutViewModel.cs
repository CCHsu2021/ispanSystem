
using MSITTeam1.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class ClassCheckOutViewModel
    {
        private TClassOrder _order = null;
        private TClassOrderDetail _orderDetail = null;
        private TClassInfo _classInfo = null;

        public ClassCheckOutViewModel()
        {
            _order = new TClassOrder();
            _orderDetail = new TClassOrderDetail();
            _classInfo = new TClassInfo();
        }
        public TClassOrder classOrder
        {
            get { return _order; }
            set { _order = value; }
        }
        public TClassOrderDetail orderDetail
        {
            get { return _orderDetail; }
            set { _orderDetail = value; }
        }

        public TClassInfo classInfo
        {
            get { return _classInfo; }
            set { _classInfo = value; }
        }

        public string OrderId
        {
            get { return this.classOrder.OrderId; }
            set { this.classOrder.OrderId = value; }
        }

        public string MemberId
        {
            get { return this.classOrder.MemberId; }
            set { this.classOrder.MemberId = value; }
        }
        public string DepartmentName
        {
            get { return this.orderDetail.DepartmentName; }
            set { this.orderDetail.DepartmentName = value; }
        }
        public string StaffEmail
        {
            get { return this.orderDetail.StaffEmail; }
            set { this.orderDetail.StaffEmail = value; }
        }
        public string StaffName
        {
            get { return this.orderDetail.StaffName; }
            set { this.orderDetail.StaffName = value; }
        }

        public DateTime? Date
        {
            get { return this.classOrder.Date; }
            set { this.classOrder.Date = value; }
        }
        public int? TotalPrice
        {
            get { return this.classOrder.TotalPrice; }
            set { this.classOrder.TotalPrice = value; }
        }
        //public string TAXID
        //{
        //    get { return this.order.Taxid; }
        //    set { this.order.Taxid = value; }
        //}
        public string PayMethod
        {
            get { return this.classOrder.PayMethod; }
            set { this.classOrder.PayMethod = value; }
        }
       
        public string imgPath
        {
            get { return this.classInfo.FClassPhotoPath; }
            set { this.classInfo.FClassPhotoPath = value; }
        }
        public int price { get; set; }
        public int count
        {
            get; set;
        }
        public int subTotal { get { return this.count * this.price; } }
        public string name
        {
            get { return this.classInfo.FClassname; }
            set { this.classInfo.FClassname = value; }
        }
        public string productId { get { return this.classInfo.FClassExponent; } set { this.classInfo.FClassExponent = value; } }
   
    }
}

