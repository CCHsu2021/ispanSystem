using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TClassOrderDetail
    {
        public string OrderId { get; set; }
        public int Id { get; set; }
        public int? Price { get; set; }
        public string ClassExponent { get; set; }
        public string MemberId { get; set; }
        public double? Discount { get; set; }
        public string DepartmentName { get; set; }
        public string StaffName { get; set; }
        public string StaffEmail { get; set; }
    }
}
