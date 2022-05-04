using MSITTeam1.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class CheckOutViewModel
    {
        private TProductOrder _order = null;
        private TProductOrderDetail _orderDetail = null;
        private TProduct _product = null;

        public CheckOutViewModel()
        {
            _order = new TProductOrder();
            _orderDetail = new TProductOrderDetail();
            _product = new TProduct();
        }
        public TProductOrder order
        {
            get { return _order; }
            set { _order = value; }
        }
        public TProductOrderDetail orderDetail
        {
            get { return _orderDetail; }
            set { _orderDetail = value; }
        }
        public TProduct product
        {
            get { return _product; }
            set { _product = value; }
        }

        public string OrderId
        {
            get { return this.order.OrderId; }
            set { this.order.OrderId = value; }
        }

        public string MemberId
        {
            get { return this.order.MemberId; }
            set { this.order.MemberId = value; }
        }
        public DateTime? Date
        {
            get { return this.order.Date; }
            set { this.order.Date = value; }
        }
        public string TotalPrice
        {
            get { return this.order.TotalPrice; }
            set { this.order.TotalPrice = value; }
        }
        public string TAXID
        {
            get { return this.order.Taxid; }
            set { this.order.Taxid = value; }
        }
        public int? PayMethod
        {
            get { return this.order.PayMethod; }
            set { this.order.PayMethod = value; }
        }
        public int? ShipBy
        {
            get { return this.order.ShipBy; }
            set { this.order.ShipBy = value; }
        }
        public string ShipTo
        {
            get { return this.order.ShipTo; }
            set { this.order.ShipTo = value; }
        }
        public string Recipient
        {
            get { return this.order.Recipient; }
            set { this.order.Recipient = value; }
        }
        public string RecipientTel
        {
            get { return this.order.RecipientTel; }
            set { this.order.RecipientTel = value; }
        }
        public string ImgPath
        {
            get { return this.product.ImgPath; }
            set { this.product.ImgPath = value; }
        }
        public int? Price
        {
            get { return this.product.Price; }
            set { this.product.Price = (int?)value; }
        }
        public int count
        {
            get; set;
        }
        public int? SubTotal
        {
            get { return this.count * this.Price; }
        }
        public string Name
        {
            get { return this.product.Name; }
            set { this.product.Name = value; }
        }
        public string ProductId { get { return this.product.ProductId; } set { this.product.ProductId = value; } }
        public List<TProductOrderDetail> orderDetailList
        {
            get; set;
        }
    }
}

