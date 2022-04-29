﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
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
    public class ClassAddToCartViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public readonly helloContext hello;
        public ClassAddToCartViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke()
        {
            if (!HttpContext.Session.Keys.Contains(CDictionary.SK_ClASS_PURCHASED_LIST+CDictionary.account))
            {
                return new HtmlContentViewComponentResult(new HtmlString("<div class='text-center py-3 font-weight-bold h5 text-secondary'>暫無商品</div>"));
            }
            else
            {
                string json = HttpContext.Session.GetString(CDictionary.SK_ClASS_PURCHASED_LIST + CDictionary.account);
                List<CClassAddToCartViewModel> cart = JsonSerializer.Deserialize<List<CClassAddToCartViewModel>>(json);
                return View(cart);
            }
        }
    }
}
