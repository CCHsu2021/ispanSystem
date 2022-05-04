﻿using MSITTeam1.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class CPointOrderViewModel
    {
        private TPointOrder _Porder = null;

        public CPointOrderViewModel()
        {
            _Porder = new TPointOrder();
        }
        public TPointOrder Porder
        {
            get { return _Porder; }
            set { _Porder = value; }
        }

        public string OrderId
        {
            get { return this.Porder.OrderId; }
            set { this.Porder.OrderId = value; }
        }

        public int? BuyPoint
        {
            get { return this.Porder.BuyPoint; }
            set { this.Porder.BuyPoint = value; }
        }
        public string CompanyTAXID
        {
            get { return this.Porder.CompanyTaxid; }
            set { this.Porder.CompanyTaxid = value; }
        }
        public int? PayMethod
        {
            get { return this.Porder.PayMethod; }
            set { this.Porder.PayMethod = value; }
        }
    }
}