using Microsoft.AspNetCore.Http;
using MSITTeam1Admin.Models;
using System;
using System.Collections.Generic;
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
        public string Name
        {
            get { return this.prodcut.Name; }
            set { this.prodcut.Name = value; }
        }
        public decimal? Price
        {
            get { return this.prodcut.Price; }
            set { this.prodcut.Price = (int?)value; }
        }
        public decimal? Cost
        {
            get { return this.prodcut.Cost; }
            set { this.prodcut.Cost = (int?)value; }
        }
        public IFormFile ImgPath { get; set; }
        public int? Barcode
        {
            get { return this.prodcut.Barcode; }
            set { this.prodcut.Barcode = value; }
        }
    }
}
