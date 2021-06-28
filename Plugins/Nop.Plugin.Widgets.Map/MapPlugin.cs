using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.Map
{
    public class MapPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly IWebHelper _webHelper;
        public MapPlugin(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }

        public bool HideInWidgetList => false;

        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/Map/Configure";
        }

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "MapWidget";
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageBeforeNews });
        }

        public override Task InstallAsync()
        {
            return base.InstallAsync();
        }
        public override Task UninstallAsync()
        {
            return base.UninstallAsync();
        }
    }
}
