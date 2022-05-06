using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class OrderDetailViewModel
    {
        private TProductOrderDetail _orderDetail = null;
        public OrderDetailViewModel()
        {
            _orderDetail = new TProductOrderDetail();
        }
        public TProductOrderDetail orderDetail
        {
            get { return _orderDetail; }
            set { _orderDetail = value; }
        }
        public string OrderId 
        { 
            get { return this.orderDetail.OrderId; }
            set { this.orderDetail.OrderId = value; } 
        }
        public int? Price
        {
            get { return this.orderDetail.Price; }
            set { this.orderDetail.Price = value; }
        }
        public int? Qty
        {
            get { return this.orderDetail.Qty; }
            set { this.orderDetail.Qty = value; }
        }

    }
}
