using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MSITTeam1.ViewComponent
{
    [Microsoft.AspNetCore.Mvc.ViewComponent]
    public class AddToCartViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;
        public AddToCartViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke()
        {
            if (!HttpContext.Session.Keys.Contains(CDictionary.SK_PRODUCTS_PURCHASED_LIST))
            {
                return Content("暫無商品");
            }
            string json = HttpContext.Session.GetString(CDictionary.SK_PRODUCTS_PURCHASED_LIST);
            List<CAddToCartViewModel> cart = JsonSerializer.Deserialize<List<CAddToCartViewModel>>(json);
            return View(cart);
        }
    }
}
