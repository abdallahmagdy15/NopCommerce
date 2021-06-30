using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Web.Models.Directory;

namespace Nop.Web.Factories
{
    /// <summary>
    /// Represents the city model factory
    /// </summary>
    public partial class CityModelFactory : ICityModelFactory
    {
        #region Fields

        private readonly ICityService _cityService;
        private readonly ILocalizationService _localizationService;
        private readonly IDistrictService _districtService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public CityModelFactory(ICityService cityService,
            ILocalizationService localizationService,
            IDistrictService districtService,
            IWorkContext workContext)
        {
            _cityService = cityService;
            _localizationService = localizationService;
            _districtService = districtService;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get states and provinces by city identifier
        /// </summary>
        /// <param name="cityId">City identifier</param>
        /// <param name="addSelectDistrictItem">Whether to add "Select district" item to list of districts</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the list of identifiers and names of Districts
        /// </returns>
        public virtual async Task<IList<DistrictModel>> GetDistrictsByCityIdAsync(string cityId, bool addSelectDistrictItem)
        {
            if (string.IsNullOrEmpty(cityId))
                throw new ArgumentNullException(nameof(cityId));

            var city = await _cityService.GetCityByIdAsync(Convert.ToInt32(cityId));
            var districts = (await _districtService
                .GetDistrictsByCityIdAsync(city?.Id ?? 0, (await _workContext.GetWorkingLanguageAsync()).Id))
                .ToList();
            var result = new List<DistrictModel>();
            foreach (var district in districts)
                result.Add(new DistrictModel
                {
                    id = district.Id,
                   //name = await _localizationService.GetLocalizedAsync(state, x => x.Name)
                   name = district.Name
                });

            if (city == null)
            {
                //city is not selected ("choose city" item)
                if (addSelectDistrictItem)
                {
                    result.Insert(0, new DistrictModel
                    {
                        id = 0,
                        //name = await _localizationService.GetResourceAsync("Address.SelectDistrict")
                        name="Select District"
                    });
                }
                else
                {
                    result.Insert(0, new DistrictModel
                    {
                        id = 0,
                        name = await _localizationService.GetResourceAsync("Address.Other")
                    });
                }
            }
            else
            {
                //some city is selected
                if (!result.Any())
                {
                    //city does not have states
                    result.Insert(0, new DistrictModel
                    {
                        id = 0,
                        name = await _localizationService.GetResourceAsync("Address.Other")
                    });
                }
                else
                {
                    //city has some districts
                    if (addSelectDistrictItem)
                    {
                        result.Insert(0, new DistrictModel
                        {
                            id = 0,
                            //name = await _localizationService.GetResourceAsync("Address.SelectDistrict")
                            name = "Select District"
                        });
                        ;
                    }
                }
            }

            return result;
        }

        #endregion
    }
}
