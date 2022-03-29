using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class StudentPortfolio
    {
        public long PortfolioId { get; set; }
        public string MemberId { get; set; }
        public string PortfolioTitle { get; set; }
        public string PortfolioDescription { get; set; }
        public string PortfolioUrl { get; set; }
    }
}
