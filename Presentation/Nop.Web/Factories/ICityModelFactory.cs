using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Web.Models.Directory;

namespace Nop.Web.Factories
{
    /// <summary>
    /// Represents the interface of the country model factory
    /// </summary>
    public partial interface ICityModelFactory
    {
        /// <summary>
        /// Get districts by city identifier
        /// </summary>
        /// <param name="cityId">Country identifier</param>
        /// <param name="addSelectDistrictItem">Whether to add "Select district" item to list of districts</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the list of identifiers and names of districts
        /// </returns>
        Task<IList<StateProvinceModel>> GetDistrictsByCityIdAsync(string cityId, bool addSelectDistrictItem);
    }
}
