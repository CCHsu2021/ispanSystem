using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSITTeam1Admin.Models;
using MSITTeam1Admin.ViewModels;

namespace MSITTeam1Admin.Controllers
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
        public IActionResult Index()
        {
            IEnumerable<TProduct> datas = null;
                datas = from t in hello.TProducts
                        select t;
            List<CProductAdminViewModel> list = new List<CProductAdminViewModel>();
            foreach (TProduct t in datas)
            {
                list.Add(new CProductAdminViewModel() { prodcut = t });
            }
            return View(list);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Type,Name,Price,Cost,ImgPath,Barcode")] TProduct tProduct, CProductAdminViewModel p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (tProduct.ProductId != p.ProductId)
                    {
                        hello.Add(tProduct);
                        await hello.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return View(tProduct);
        }

        // GET: Products/Edit/5

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                TProduct prod = hello.TProducts.FirstOrDefault(c => c.ProductId == id.ToString());
                if (prod != null)
                {
                    return View(new CProductAdminViewModel() { prodcut = prod });
                }
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Edit(CProductAdminViewModel p)
        {
            TProduct prod = hello.TProducts.FirstOrDefault(c => c.ProductId == p.ProductId);
            if (prod != null)
            {
                if (p.ImgPath != null)
                {
                    string photoName = Guid.NewGuid().ToString() + ".jpg";
                    prod.ImgPath = photoName;
                    p.ImgPath.CopyTo(new FileStream(_enviroment.WebRootPath + @"\images\" + photoName, FileMode.Create));
                }
                prod.ProductId = p.ProductId;
                prod.Name = p.Name;
                prod.Price = p.Price;
                prod.Cost = p.Cost;
                prod.Barcode = p.Barcode;
                prod.ImgPath = p.ImgPath;
                hello.SaveChanges();
            }
            return RedirectToAction("List");
        }

        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tProduct = await hello.TProducts.FindAsync(id);
        //    if (tProduct == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(tProduct);
        //}

        //// POST: Products/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("ProductId,Type,Name,Price,Cost,ImgPath,Barcode")] TProduct tProduct)
        //{
        //    if (id != tProduct.ProductId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            hello.Update(tProduct);
        //            await hello.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TProductExists(tProduct.ProductId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tProduct);
        //}

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tProduct = await hello.TProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tProduct == null)
            {
                return NotFound();
            }

            return View(tProduct);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tProduct = await hello.TProducts.FindAsync(id);
            hello.TProducts.Remove(tProduct);
            await hello.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TProductExists(string id)
        {
            return hello.TProducts.Any(e => e.ProductId == id);
        }
    }
}
