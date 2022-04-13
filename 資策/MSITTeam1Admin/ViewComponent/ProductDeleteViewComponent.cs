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
    public class ProductDeleteViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;

        public ProductDeleteViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke(string id)
        {
            if (id != null)
            {
                TProduct prod = hello.TProducts.FirstOrDefault(c => c.ProductId == id.ToString());
                if (prod != null)
                {
                    return View(new CProductAdminViewModel() { prodcut = prod });
                }
            }
            return View(".. / Product / Index");
        }
    }
}
