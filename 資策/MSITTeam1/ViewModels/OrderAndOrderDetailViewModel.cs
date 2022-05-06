using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class OrderAndOrderDetailViewModel
    {
        public List<CheckOutViewModel> Order { get; set; }

        public List<OrderDetailViewModel> OrderDetail { get; set; }
    }
}
