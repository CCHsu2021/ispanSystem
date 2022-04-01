using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;

namespace MSITTeam1.Controllers
{
    public class ProductsController : Controller
    {

        private readonly helloContext hello;
        IWebHostEnvironment _enviroment;

        public ProductsController(helloContext _hello, IWebHostEnvironment p)
        {
            hello = _hello;
            _enviroment = p;
        }
        public IActionResult Index(CQueryKeywordForProductViewModel vModel, CProductViewModel p)
        {
            IEnumerable<TProduct> datas = null;
            string keyword = vModel.txtKeyword;
            if (string.IsNullOrEmpty(keyword))
            {
                datas = from t in hello.TProducts
                        select t;
            }
            else
            {
                datas = hello.TProducts.Where(t => t.Name.Contains(keyword) || (t.Barcode).ToString().Contains(keyword));
            }

            //TProduct prod = hello.TProducts.FirstOrDefault(c => c.ProductId == p.ProductId);
            //if (prod != null)
            //{
            //    if (p.ImgPath == null)
            //    {
            //        string photoName = "noImg.jpg";
            //        prod.ImgPath = photoName;
            //    }
            //}

            List<CProductViewModel> list = new List<CProductViewModel>();
            foreach (TProduct t in datas)
            {
                list.Add(new CProductViewModel() { prodcut = t });
            }
            return View(list);
        }

        // GET: Products/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tProduct = await _context.TProducts
        //        .FirstOrDefaultAsync(m => m.ProductId == id);
        //    if (tProduct == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tProduct);
        //}
    }
}
