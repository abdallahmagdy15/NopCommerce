using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Controllers
{
    public partial class CityController : BasePublicController
	{
        #region Fields

        private readonly ICityModelFactory _cityModelFactory;
        
        #endregion
        
        #region Ctor

        public CityController(ICityModelFactory cityModelFactory)
		{
            _cityModelFactory = cityModelFactory;
		}
        
        #endregion
        
        #region Districts

        //available even when navigation is not allowed
        [CheckAccessPublicStore(true)]
        //ignore SEO friendly URLs checks
        [CheckLanguageSeoCode(true)]
        public virtual async Task<IActionResult> GetDistrictsByCityId(string cityId, bool addSelectDistrictItem)
        {
            var model = await _cityModelFactory.GetDistrictsByCityIdAsync(cityId, addSelectDistrictItem);
            
            return Json(model);
        }
        
        #endregion
    }
}