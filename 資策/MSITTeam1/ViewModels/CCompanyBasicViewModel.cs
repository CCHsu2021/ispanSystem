using Microsoft.AspNetCore.Http;
using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class CCompanyBasicViewModel
    {
        private TCompanyBasic _com = null;
        public IFormFile photo { get; set; }
        public CCompanyBasicViewModel()
        {
            _com = new TCompanyBasic();
        }
        public TCompanyBasic com { get { return _com; } set { _com = value; } }
        [DisplayName("統編")]
        public string CompanyTaxid { get { return this._com.CompanyTaxid; } set { this._com.CompanyTaxid = value; } }
        [DisplayName("公司名稱")]
        public string FName { get { return this._com.FName; } set { this._com.FName = value; } }
        [DisplayName("員工總數")]
        public int? FCapitalAmount { get { return this._com.FCapitalAmount; } set { this._com.FCapitalAmount = value; } }
        [DisplayName("電話區碼")]
        public int? FPhoneCode { get { return this._com.FPhoneCode; } set { this._com.FPhoneCode = value; } }
        [DisplayName("電話")]
        public int? FPhone { get { return this._com.FPhone; } set { this._com.FPhone = value; } }
        [DisplayName("傳真區碼")]
        public int? FFaxCode { get { return this._com.FFaxCode; } set { this._com.FFaxCode = value; } }
        [DisplayName("傳真")]
        public int? FFax { get { return this._com.FFax; } set { this._com.FFax = value; } }
        [DisplayName("聯絡人")]
        public string FContactPerson { get { return this._com.FContactPerson; } set { this._com.FContactPerson = value; } }
        [DisplayName("地址")]
        public string FAddress { get { return this._com.FAddress; } set { this._com.FAddress = value; } }
        [DisplayName("區碼")]
        public string FDistrictCode { get { return this._com.FDistrictCode; } set { this._com.FDistrictCode = value; } }
        [DisplayName("福利")]
        public string FBenefits { get { return this._com.FBenefits; } set { this._com.FBenefits = value; } }
        [DisplayName("信箱")]
        public string FEmail { get { return this._com.FEmail; } set { this._com.FEmail = value; } }
        [DisplayName("Logo")]
        public string FLogo { get { return this._com.FLogo; } set { this._com.FLogo = value; } }
        [DisplayName("簡介")]
        public string FCustomInfo { get { return this._com.FCustomInfo; } set { this._com.FCustomInfo = value; } }
        public int? FLevel { get { return this._com.FLevel; } set { this._com.FLevel = value; } }
        public string FDueDate { get { return this._com.FDueDate; } set { this._com.FDueDate = value; } }
        public int FPointState { get { return this._com.FPointState; } set { this._com.FPointState = value; } }
        [DisplayName("城市")]
        public string FCity { get { return this._com.FCity; } set { this._com.FCity = value; } }
        [DisplayName("區")]
        public string FDistrict { get { return this._com.FDistrict; } set { this._com.FDistrict = value; } }
    }
}
