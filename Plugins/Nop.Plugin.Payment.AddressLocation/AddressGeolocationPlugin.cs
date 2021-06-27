using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Common;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Payment.AddressLocation
{
    public class AddressGeolocationPlugin : BasePlugin,IWidgetPlugin
    {
        private readonly IWebHelper _webHelper;
        public AddressGeolocationPlugin(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }

        public bool HideInWidgetList => throw new System.NotImplementedException();

        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/AddressGeolocation/Configure";
        }

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "MapWidget";
        }

        public async Task<IList<string>> GetWidgetZonesAsync()
        {
            return new List<string> { PublicWidgetZones.CheckoutBillingAddressTop };
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
