using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Caching;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;
using Nop.Data;
using Nop.Services.Localization;

namespace Nop.Services.Directory
{
    /// <summary>
    /// State province service
    /// </summary>
    public partial class CityService : ICityService
    {
        #region Fields

        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<City> _cityRepository;

        #endregion

        #region Ctor

        public CityService(IStaticCacheManager staticCacheManager,
            ILocalizationService localizationService,
            IRepository<City> cityRepository)
        {
            _staticCacheManager = staticCacheManager;
            _localizationService = localizationService;
            _cityRepository = cityRepository;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Deletes a state/province
        /// </summary>
        /// <param name="City">The state/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteCityAsync(City City)
        {
            await _cityRepository.DeleteAsync(City);
        }

        /// <summary>
        /// Gets a state/province
        /// </summary>
        /// <param name="cityId">The state/province identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the state/province
        /// </returns>
        public virtual async Task<City> GetCityByIdAsync(int cityId)
        {
            return await _cityRepository.GetByIdAsync(cityId, cache => default);
        }

        

        /// <summary>
        /// Gets a state/province by address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the country
        /// </returns>
        public virtual async Task<City> GetCityByAddressAsync(Address address)
        {
            return await GetCityByIdAsync(address?.CityId ?? 0);
        }

        /// <summary>
        /// Gets a state/province collection by country identifier
        /// </summary>
        /// <param name="countryId">Country identifier</param>
        /// <param name="languageId">Language identifier. It's used to sort states by localized names (if specified); pass 0 to skip it</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the states
        /// </returns>
        public virtual async Task<IList<City>> GetCitysByCountryIdAsync(int countryId, int languageId = 0, bool showHidden = false)
        {
            var key = _staticCacheManager.PrepareKeyForDefaultCache(NopDirectoryDefaults.CitysByCountryCacheKey, countryId, languageId, showHidden);

            return await _staticCacheManager.GetAsync(key, async () =>
            {
                var query = from sp in _cityRepository.Table
                            orderby sp.DisplayOrder, sp.Name
                            where sp.CountryId == countryId &&
                            (showHidden || sp.Published)
                            select sp;
                var citys = await query.ToListAsync();

                if (languageId > 0)
                    //we should sort states by localized names when they have the same display order
                    citys = await citys.ToAsyncEnumerable()
                        .OrderBy(c => c.DisplayOrder)
                        .ThenByAwait(async c => await _localizationService.GetLocalizedAsync(c, x => x.Name, languageId))
                        .ToListAsync();

                return citys;
            });
        }

        /// <summary>
        /// Gets all states/provinces
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the states
        /// </returns>
        public virtual async Task<IList<City>> GetCitysAsync(bool showHidden = false)
        {
            var query = from sp in _cityRepository.Table
                        orderby sp.CountryId, sp.DisplayOrder, sp.Name
                        where showHidden || sp.Published
                        select sp;


            var citys = await _staticCacheManager.GetAsync(_staticCacheManager.PrepareKeyForDefaultCache(NopDirectoryDefaults.CitysAllCacheKey, showHidden), async () => await query.ToListAsync());

            return citys;
        }

        /// <summary>
        /// Inserts a state/province
        /// </summary>
        /// <param name="City">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertCityAsync(City City)
        {
            await _cityRepository.InsertAsync(City);
        }

        /// <summary>
        /// Updates a state/province
        /// </summary>
        /// <param name="City">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateCityAsync(City City)
        {
            await _cityRepository.UpdateAsync(City);
        }

        #endregion
    }
}