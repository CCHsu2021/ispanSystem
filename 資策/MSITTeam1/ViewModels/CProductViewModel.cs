using Microsoft.AspNetCore.Http;
using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewModels
{
    public class CProductViewModel
    {
        private TProduct _product = null;
        public CProductViewModel()
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
        public int? Price
        {
            get { return this.prodcut.Price; }
            set { this.prodcut.Price = (int?)value; }
        }
        public int? Cost
        {
            get { return this.prodcut.Cost; }
            set { this.prodcut.Cost = (int?)value; }
        }
        public IFormFile photo { get; set; }
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
