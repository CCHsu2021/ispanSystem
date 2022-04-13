using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MSITTeam1Admin.Models;
using MSITTeam1Admin.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MSITTeam1Admin.ViewComponent
{
    [Microsoft.AspNetCore.Mvc.ViewComponent]
    public class ProductCreateViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;

        public ProductCreateViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke()
        {
            var pid = hello.TProducts.Max(t => t.ProductId);
            if (pid != null)
            {
                int proid = int.Parse(pid.Substring(1, 8)) + 1;
                ViewBag.productId = $"P" + proid.ToString("00000000");
            }
            else
            {
                ViewBag.productId = "P00000001";
            }
            return View(".. / Product / Index");
        }
    }
}
