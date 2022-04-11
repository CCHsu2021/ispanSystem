using Microsoft.AspNetCore.Http;
using MSITTeam1Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1Admin.ViewModels
{
    public class CProductAdminViewModel
    {
        private TProduct _product = null;
        public CProductAdminViewModel()
        {
            _product = new TProduct();
        }
        public TProduct prodcut
        {
            get { return _product; }
            set { _product = value; }
        }
        public string ProductId { get { return this.prodcut.ProductId; } set { this.prodcut.ProductId = value; } }
        public int? Type { get { return this.prodcut.Type; } set { this.prodcut.Type = value; } }
        [DisplayName("產品名稱")]
        [Required(ErrorMessage = "產品名稱不得為空")]
        public string Name
        {
            get { return this.prodcut.Name; }
            set { this.prodcut.Name = value; }
        }
        [DisplayName("售價")]
        [Required(ErrorMessage = "售價不得為空")]
        [Range(1, 9999999999, ErrorMessage = "售價不可為負數或等於0")]
        public int? Price
        {
            get { return this.prodcut.Price; }
            set { this.prodcut.Price = (int?)value; }
        }
        [DisplayName("成本")]
        public int? Cost
        {
            get { return this.prodcut.Cost; }
            set { this.prodcut.Cost = (int?)value; }
        }
        public IFormFile photo { get; set; }
        [DisplayName("產品介紹")]
        public string Description
        {
            get { return this.prodcut.Description; }
            set { this.prodcut.Description = value; }
        }
        [DisplayName("產品圖片")]
        public string ImgPath
        {
            get { return this.prodcut.ImgPath; }
            set { this.prodcut.ImgPath = value; }
        }
        public int? Barcode
        {
            get { return this.prodcut.Barcode; }
            set { this.prodcut.Barcode = value; }
        }
    }
}
