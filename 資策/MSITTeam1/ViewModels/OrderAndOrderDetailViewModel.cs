using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MSITTeam1.Models;

namespace MSITTeam1.ViewModels
{
    public class OrderAndOrderDetailViewModel
    {
        public List<CheckOutViewModel> order { get; set; }

        public List<OrderDetailViewModel> orderDetail { get; set; }
        public List<CProductViewModel> product { get; set; }
    }

}
