using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;

namespace Nop.Services.Directory
{
    /// <summary>
    /// State province service interface
    /// </summary>
    public partial interface IDistrictService
    {
        /// <summary>
        /// Deletes a state/province
        /// </summary>
        /// <param name="district">The state/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteDistrictAsync(District district);

        /// <summary>
        /// Gets a state/province
        /// </summary>
        /// <param name="districtId">The state/province identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the state/province
        /// </returns>
        Task<District> GetDistrictByIdAsync(int districtId);

        /// <summary>
        /// Gets a state/province by address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the country
        /// </returns>
        Task<District> GetDistrictByAddressAsync(Address address);

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
        Task<IList<District>> GetDistrictsByCityIdAsync(int cityId, int languageId = 0, bool showHidden = false);

        /// <summary>
        /// Gets all states/provinces
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the states
        /// </returns>
        Task<IList<District>> GetDistrictsAsync(bool showHidden = false);

        /// <summary>
        /// Inserts a state/province
        /// </summary>
        /// <param name="district">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertDistrictAsync(District district);

        /// <summary>
        /// Updates a state/province
        /// </summary>
        /// <param name="district">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateDistrictAsync(District district);
    }
}
