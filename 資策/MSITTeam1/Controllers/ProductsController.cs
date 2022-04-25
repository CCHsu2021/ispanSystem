using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System.Text.Json;

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
                if (prod != null)
                {
                    return View(new CProductViewModel() { prodcut = prod });
                }
            }
            return NotFound();
        }
        #endregion

        #region 加入購物車
        public IActionResult AddToCart(string id)
        {
            if (id != null)
            {
                TProduct prod = hello.TProducts.FirstOrDefault(c => c.ProductId == id);
                if (prod != null)
                {
                    string json = "";
                    List<CAddToCartViewModel> cart = new List<CAddToCartViewModel>();
                    CAddToCartViewModel item = new CAddToCartViewModel()
                    {
                        count = 1,
                        price = (int)(prod.Price),
                        productId = prod.ProductId,
                        product = prod,
                        name = prod.Name,
                        imgPath = prod.ImgPath,
                    };
                    if (HttpContext.Session.Keys.Contains(CDictionary.SK_PRODUCTS_PURCHASED_LIST))
                    {
                        json = HttpContext.Session.GetString(CDictionary.SK_PRODUCTS_PURCHASED_LIST);
                        cart = JsonSerializer.Deserialize<List<CAddToCartViewModel>>(json);
                        int index = cart.FindIndex(m => m.productId.Equals(id));
                        if (index != -1)
                        {
                            cart[index].count += item.count;
                        }
                        else
                        {
                            cart.Add(item);
                        }
                        json = JsonSerializer.Serialize(cart);
                        HttpContext.Session.SetString(CDictionary.SK_PRODUCTS_PURCHASED_LIST, json);
                    }
                    else
                    {
                        cart = new List<CAddToCartViewModel>();
                        cart.Add(item);
                        json = JsonSerializer.Serialize(cart);
                        HttpContext.Session.SetString(CDictionary.SK_PRODUCTS_PURCHASED_LIST, json);
                    }
                }
            }
            return RedirectToAction("Index");
        }
        #endregion 

        #region 移出購物車
        public IActionResult DeleteFromCart(string id)
        {
            if (id != null)
            {
                TProduct prod = hello.TProducts.FirstOrDefault(c => c.ProductId == id);
                if (prod != null)
                {
                    string json = "";
                    List<CAddToCartViewModel> cart = new List<CAddToCartViewModel>();
                    if (HttpContext.Session.Keys.Contains(CDictionary.SK_PRODUCTS_PURCHASED_LIST))
                    {
                        json = HttpContext.Session.GetString(CDictionary.SK_PRODUCTS_PURCHASED_LIST);
                        cart = JsonSerializer.Deserialize<List<CAddToCartViewModel>>(json);
                        int index = cart.FindIndex(m => m.productId.Equals(id));
                        cart.RemoveAt(index);
                        if (cart.Count < 1)
                        {
                            HttpContext.Session.Remove(CDictionary.SK_PRODUCTS_PURCHASED_LIST);
                        }
                        else
                        {
                            json = JsonSerializer.Serialize(cart);
                            HttpContext.Session.SetString(CDictionary.SK_PRODUCTS_PURCHASED_LIST, json);
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

    }
}
