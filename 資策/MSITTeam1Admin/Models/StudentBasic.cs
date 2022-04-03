using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1Admin.Models
{
    public partial class StudentBasic
    {
        public string MemberId { get; set; }
        public string FAccount { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactAddress { get; set; }
        public string Autobiography { get; set; }
        public string Portrait { get; set; }
        public string FClassMessage { get; set; }
        public string FCompany { get; set; }
        public string FCity { get; set; }
        public string FDistrict { get; set; }
        public byte[] FPassword { get; set; }
        public byte[] FSalt { get; set; }
        public string FGuid { get; set; }
        public string FDateTime { get; set; }
        public int? FMemberType { get; set; }
        public string Member { get; set; }
        public string FCheckStatus { get; set; }
    }
}
