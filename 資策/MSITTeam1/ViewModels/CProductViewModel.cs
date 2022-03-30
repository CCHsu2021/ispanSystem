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
        public string ProductId { get; set; }
        public int? Type { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? Cost { get; set; }
        public IFormFile ImgPath { get; set; }
        public int? Barcode { get; set; }
    }
}
