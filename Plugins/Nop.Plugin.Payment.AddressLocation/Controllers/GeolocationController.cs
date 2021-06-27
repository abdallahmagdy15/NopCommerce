using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Payment.AddressGeolocation.Domains;
using Nop.Plugin.Payment.AddressGeolocation.Models;
using Nop.Plugin.Payment.AddressGeolocation.Services;
using Nop.Services.Common;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class GeolocationController : BasePluginController
    {
        private readonly AddressGeolocationService _geolocationService;
        private readonly AddressService _addressService;

        public GeolocationController(AddressGeolocationService geolocationService , AddressService addressService)
        {
            _geolocationService = geolocationService;
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LocationViewModel model)
        {
            if (ModelState.IsValid)
            {
                //add to geolocation table in db 
                var domianModel = new Geolocation()
                {
                    Latitude = model.Latitude,
                    Longitude = model.Longitude
                };
               await _geolocationService.AddGeolocationAsync(domianModel);
                //update address table in db with geolocation 
                //_addressService.update....
            }
            return View(model);
        }

        //[AuthorizeAdmin]
        //[Area(AreaNames.Admin)]
        //[HttpPost, ActionName("Configure")]
        //[FormValueRequired("save")]
        //public async Task<IActionResult> Configure(ConfigurationModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return await Configure();

        //    var storeId = await _storeContext.GetActiveStoreScopeConfigurationAsync();
        //    var sendinblueSettings = await _settingService.LoadSettingAsync<SendinblueSettings>(storeId);

        //    //set API key
        //    sendinblueSettings.ApiKey = model.ApiKey;
        //    await _settingService.SaveSettingAsync(sendinblueSettings, settings => settings.ApiKey, clearCache: false);
        //    await _settingService.ClearCacheAsync();

        //    _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

        //    return await Configure();
        //}

    }
}
