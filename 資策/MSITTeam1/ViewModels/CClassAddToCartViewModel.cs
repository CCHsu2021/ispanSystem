using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class CClassAddToCartViewModel
    {
        public string productId { get; set; }

        public int count { get; set; }
        public int price { get; set; }
        public decimal subTotal { get { return this.count * this.price; } }
        public string imgPath { get; set; }
        public string name { get; set; }

        public TClassInfo TClassInfo { get; set; }
    }
}
