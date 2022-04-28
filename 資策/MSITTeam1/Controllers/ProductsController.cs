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
                    if (HttpContext.Session.Keys.Contains(CDictionary.SK_PRODUCTS_PURCHASED_LIST + CDictionary.account))
                    {
                        json = HttpContext.Session.GetString(CDictionary.SK_PRODUCTS_PURCHASED_LIST + CDictionary.account);
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
                        HttpContext.Session.SetString(CDictionary.SK_PRODUCTS_PURCHASED_LIST + CDictionary.account, json);
                    }
                    else
                    {
                        cart = new List<CAddToCartViewModel>();
                        cart.Add(item);
                        json = JsonSerializer.Serialize(cart);
                        HttpContext.Session.SetString(CDictionary.SK_PRODUCTS_PURCHASED_LIST + CDictionary.account, json);
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
                    if (HttpContext.Session.Keys.Contains(CDictionary.SK_PRODUCTS_PURCHASED_LIST + CDictionary.account))
                    {
                        json = HttpContext.Session.GetString(CDictionary.SK_PRODUCTS_PURCHASED_LIST + CDictionary.account);
                        cart = JsonSerializer.Deserialize<List<CAddToCartViewModel>>(json);
                        int index = cart.FindIndex(m => m.productId.Equals(id));
                        cart.RemoveAt(index);
                        if (cart.Count < 1)
                        {
                            HttpContext.Session.Remove(CDictionary.SK_PRODUCTS_PURCHASED_LIST + CDictionary.account);
                        }
                        else
                        {
                            json = JsonSerializer.Serialize(cart);
                            HttpContext.Session.SetString(CDictionary.SK_PRODUCTS_PURCHASED_LIST + CDictionary.account, json);
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region 加入購物車Detail版
        public IActionResult DetailAddToCart(string id, int count)
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
                        count = count,
                        price = (int)(prod.Price),
                        productId = prod.ProductId,
                        product = prod,
                        name = prod.Name,
                        imgPath = prod.ImgPath,
                    };
                    if (HttpContext.Session.Keys.Contains(CDictionary.SK_PRODUCTS_PURCHASED_LIST + CDictionary.account))
                    {
                        json = HttpContext.Session.GetString(CDictionary.SK_PRODUCTS_PURCHASED_LIST + CDictionary.account);
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
                        HttpContext.Session.SetString(CDictionary.SK_PRODUCTS_PURCHASED_LIST + CDictionary.account, json);
                    }
                    else
                    {
                        cart = new List<CAddToCartViewModel>();
                        cart.Add(item);
                        json = JsonSerializer.Serialize(cart);
                        HttpContext.Session.SetString(CDictionary.SK_PRODUCTS_PURCHASED_LIST + CDictionary.account, json);
                    }
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region 課程商品列表
        public IActionResult classIndex(CQueryKeywordForProductViewModel vModel)
        {
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;
            IEnumerable<TClassInfo> datas = null;
            string keyword = vModel.txtKeyword;
            if (string.IsNullOrEmpty(keyword))
            {
                datas = from t in hello.TClassInfos
                        select t;
            }
            else
            {
                datas = hello.TClassInfos.Where(t => t.FClassname.Contains(keyword) || t.FClassAdress.Contains(keyword));
            }

            return View(datas);
        }
        #endregion

        #region 課程商品詳情
        public IActionResult classDetails(string id)
        {
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;
            if (id != null)
            {
                ViewBag.Id = id;
              return View();
            }
            return NotFound();
        }
        #endregion

        #region 課程加入購物車
        public IActionResult ClassAddToCart(string id)
        {
            if (id != null)
            {
                TClassInfo prod = hello.TClassInfos.FirstOrDefault(c => c.FClassExponent == id);
                if (prod != null)
                {
                    string json = "";
                    var key = CDictionary.SK_ClASS_PURCHASED_LIST + CDictionary.account;
                    List<CClassAddToCartViewModel> cart = new List<CClassAddToCartViewModel>();
                    CClassAddToCartViewModel item = new CClassAddToCartViewModel()
                    {
                        count = 1,
                        price = int.Parse(prod.FClassmoney),
                        productId = prod.FClassExponent,
                        TClassInfo = prod,
                        name = prod.FClassname,
                        imgPath = prod.FClassPhotoPath,
                    };
                    if (HttpContext.Session.Keys.Contains(key))
                    {
                        json = HttpContext.Session.GetString(key);
                        cart = JsonSerializer.Deserialize<List<CClassAddToCartViewModel>>(json);
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
                        HttpContext.Session.SetString(key, json);
                    }
                    else
                    {
                        cart = new List<CClassAddToCartViewModel>();
                        cart.Add(item);
                        json = JsonSerializer.Serialize(cart);
                        HttpContext.Session.SetString(key, json);
                    }
                }
            }
            return RedirectToAction("classIndex");
        }
        #endregion

        #region 課程移出購物車
        public IActionResult classDeleteFromCart(string id)
        {
            if (id != null)
            {
                TClassInfo prod = hello.TClassInfos.FirstOrDefault(c => c.FClassExponent == id);
                if (prod != null)
                {
                    string json = "";
                    var key = CDictionary.SK_ClASS_PURCHASED_LIST + CDictionary.account;
                    List<CClassAddToCartViewModel> cart = new List<CClassAddToCartViewModel>();
                    if (HttpContext.Session.Keys.Contains(key))
                    {
                        json = HttpContext.Session.GetString(key);
                        cart = JsonSerializer.Deserialize<List<CClassAddToCartViewModel>>(json);
                        int index = cart.FindIndex(m => m.productId.Equals(id));
                        cart.RemoveAt(index);
                        if (cart.Count < 1)
                        {
                            HttpContext.Session.Remove(key);
                        }
                        else
                        {
                            json = JsonSerializer.Serialize(cart);
                            HttpContext.Session.SetString(key, json);
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region 課程加入購物車Detail版
        public IActionResult classDetailAddToCart(string id, int count)
        {
            if (id != null)
            {
                TClassInfo prod = hello.TClassInfos.FirstOrDefault(c => c.FClassExponent == id);
                if (prod != null)
                {
                    string json = "";
                    var key = CDictionary.SK_ClASS_PURCHASED_LIST + CDictionary.account;
                    List<CClassAddToCartViewModel> cart = new List<CClassAddToCartViewModel>();
                    CClassAddToCartViewModel item = new CClassAddToCartViewModel()
                    {
                        count = count,
                        price = int.Parse(prod.FClassmoney),
                        productId = prod.FClassExponent,
                        TClassInfo = prod,
                        name = prod.FClassname,
                        imgPath = prod.FClassPhotoPath
                    };
                    if (HttpContext.Session.Keys.Contains(key))
                    {
                        json = HttpContext.Session.GetString(key);
                        cart = JsonSerializer.Deserialize<List<CClassAddToCartViewModel>>(json);
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
                        HttpContext.Session.SetString(key, json);
                    }
                    else
                    {
                        cart = new List<CClassAddToCartViewModel>();
                        cart.Add(item);
                        json = JsonSerializer.Serialize(cart);
                        HttpContext.Session.SetString(key, json);
                    }
                }
            }
            return RedirectToAction("classIndex");
        }
        #endregion
    }
}
