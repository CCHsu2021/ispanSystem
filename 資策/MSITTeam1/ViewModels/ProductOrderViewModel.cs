using MSITTeam1.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class ProductOrderViewModel
    {
        private TProductOrder _order = null;

        public ProductOrderViewModel()
        {
            _order = new TProductOrder();
        }
        public TProductOrder order
        {
            get { return this._order; }
            set {this. _order = value; }
        }

        public string OrderId
        {
            get { return this._order.OrderId; }
            set { this._order.OrderId = value; }
        }

        public string MemberId
        {
            get { return this._order.MemberId; }
            set { this._order.MemberId = value; }
        }
        public DateTime? Date
        {
            get { return this._order.Date; }
            set { this._order.Date = value; }
        }
        public string TotalPrice
        {
            get { return this._order.TotalPrice; }
            set { this._order.TotalPrice = value; }
        }
        public string TAXID
        {
            get { return this._order.Taxid; }
            set { this._order.Taxid = value; }
        }
        public string PayMethod
        {
            get { return this._order.PayMethod; }
            set { this._order.PayMethod = value; }
        }
        public string ShipBy
        {
            get { return this._order.ShipBy; }
            set { this._order.ShipBy = value; }
        }
        public string ShipTo
        {
            get { return this._order.ShipTo; }
            set { this._order.ShipTo = value; }
        }
        public string Recipient
        {
            get { return this._order.Recipient; }
            set { this._order.Recipient = value; }
        }
        public string RecipientTel
        {
            get { return this._order.RecipientTel; }
            set { this._order.RecipientTel = value; }
        }
        public string Invoice
        {
            get { return this._order.Invoice; }
            set { this._order.Invoice = value; }
        }
        public int? Discount 
        {
            get { return this._order.Discount; }
            set { this._order.Discount = value; }
        }
    }
}







