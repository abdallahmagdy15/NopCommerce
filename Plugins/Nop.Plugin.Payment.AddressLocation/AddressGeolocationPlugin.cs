using System.Threading.Tasks;
using Nop.Core;
using Nop.Services.Common;
using Nop.Services.Plugins;

namespace Nop.Plugin.Payment.AddressLocation
{
    public class AddressGeolocationPlugin : BasePlugin
    {
        private readonly IWebHelper _webHelper;
        public AddressGeolocationPlugin(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/AddressGeolocation/Configure";
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
