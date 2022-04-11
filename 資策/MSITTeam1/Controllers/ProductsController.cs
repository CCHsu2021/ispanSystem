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

        public ProductsController(helloContext _hello)
        {
            hello = _hello;
        }

        #region 商品列表
        public IActionResult Index(CQueryKeywordForProductViewModel vModel)
        {
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;
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

            List<CProductViewModel> list = new List<CProductViewModel>();
            foreach (TProduct t in datas)
            {
                list.Add(new CProductViewModel() { prodcut = t });
            }
            return View(list);
        }
        #endregion

        #region 商品詳情
        public IActionResult Details(string id)
        {
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;
            if (id != null)
            {
                TProduct prod = hello.TProducts.FirstOrDefault(t => t.ProductId == id);
                if(prod != null)
                {
                    return View(new CProductViewModel() { prodcut = prod });
                }
            }
            return NotFound();
        }
        #endregion
    }
}
