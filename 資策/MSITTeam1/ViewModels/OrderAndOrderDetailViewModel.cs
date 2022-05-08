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
        public List<ClassCheckOutViewModel> classOrder { get; set; }
        public List<ClassOrderDetailViewModel> classOrderDetail { get; set; }
        public List<TClassInfo> ClassInfo { get; set; }
        public List<CPointOrderViewModel> Porder { get; set; }

    }
}
