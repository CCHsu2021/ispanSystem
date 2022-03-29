using System;
using System.Collections.Generic;

#nullable disable

namespace MSITTeam1.Models
{
    public partial class TCompanyBasic
    {
        public TCompanyBasic()
        {
            TJobVacancies = new HashSet<TJobVacancy>();
        }

        public string CompanyTaxid { get; set; }
        public string FName { get; set; }
        public int? FCapitalAmount { get; set; }
        public int? FPhoneCode { get; set; }
        public int? FPhone { get; set; }
        public int? FFaxCode { get; set; }
        public int? FFax { get; set; }
        public string FContactPerson { get; set; }
        public string FAddress { get; set; }
        public string FDistrictCode { get; set; }
        public string FBenefits { get; set; }
        public string FEmail { get; set; }
        public byte[] FLogo { get; set; }
        public string FCustomInfo { get; set; }
        public int? FLevel { get; set; }
        public string FDueDate { get; set; }
        public int FPointState { get; set; }
        public string FCity { get; set; }
        public string FDistrict { get; set; }
        public byte[] FPassword { get; set; }
        public byte[] FSalt { get; set; }

        public virtual ICollection<TJobVacancy> TJobVacancies { get; set; }
    }
}
