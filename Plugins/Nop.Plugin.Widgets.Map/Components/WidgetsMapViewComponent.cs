using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.Map.Components
{
    [ViewComponent(Name = "WidgetsMap")]
    class WidgetsMapViewComponent : NopViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Plugins/Widgets.Map/Views/Map/Index.cshtml");
        }
    }
}
