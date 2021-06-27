using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Payment.AddressGeolocation.Components
{
    class MapWidgetViewComponent : NopViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Plugins/Nop.Plugin.Payment.AddressLocation/Views/Geolocation/Index.cshtml");
        }
    }
}
