using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.Map.Components
{
    class MapWidgetViewComponent : NopViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Plugins/Widgets.Map/Views/Map/Index.cshtml");
        }
    }
}
