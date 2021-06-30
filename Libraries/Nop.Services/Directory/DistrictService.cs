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
    public partial class DistrictService : IDistrictService
    {
        #region Fields

        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<District> _districtRepository;

        #endregion

        #region Ctor

        public DistrictService(IStaticCacheManager staticCacheManager,
            ILocalizationService localizationService,
            IRepository<District> districtRepository)
        {
            _staticCacheManager = staticCacheManager;
            _localizationService = localizationService;
            _districtRepository = districtRepository;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Deletes a state/province
        /// </summary>
        /// <param name="district">The state/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteDistrictAsync(District district)
        {
            await _districtRepository.DeleteAsync(district);
        }

        /// <summary>
        /// Gets a state/province
        /// </summary>
        /// <param name="districtId">The state/province identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the state/province
        /// </returns>
        public virtual async Task<District> GetDistrictByIdAsync(int districtId)
        {
            return await _districtRepository.GetByIdAsync(districtId, cache => default);
        }



        /// <summary>
        /// Gets a state/province by address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the country
        /// </returns>
        public virtual async Task<District> GetDistrictByAddressAsync(Address address)
        {
            return await GetDistrictByIdAsync(address?.DistrictId ?? 0);
        }

        /// <summary>
        /// Gets all states/provinces
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the states
        /// </returns>
        public virtual async Task<IList<District>> GetDistrictsAsync(bool showHidden = false)
        {
            var query = from sp in _districtRepository.Table
                        orderby sp.CityId, sp.Name
                        where showHidden
                        select sp;


            //var districts = await _staticCacheManager.GetAsync(_staticCacheManager.PrepareKeyForDefaultCache(NopDirectoryDefaults.DistrictsAllCacheKey, showHidden), async () => await query.ToListAsync());

            return await query.ToListAsync();
        }

        /// <summary>
        /// Inserts a state/province
        /// </summary>
        /// <param name="district">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertDistrictAsync(District district)
        {
            await _districtRepository.InsertAsync(district);
        }

        /// <summary>
        /// Updates a state/province
        /// </summary>
        /// <param name="district">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateDistrictAsync(District district)
        {
            await _districtRepository.UpdateAsync(district);
        }

        public async Task<IList<District>> GetDistrictsByCityIdAsync(int cityId, int languageId = 0, bool showHidden = false)
        {
            var query = from sp in _districtRepository.Table
                        orderby sp.DisplayOrder,sp.Name
                        where sp.CityId== cityId
                        select sp;
            var districts = await query.ToListAsync();
            return districts;
        }

        #endregion
    }
}