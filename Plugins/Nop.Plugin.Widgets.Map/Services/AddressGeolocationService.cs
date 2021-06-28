using System.Threading.Tasks;
using Nop.Data;
using Nop.Plugin.Widgets.Map.Domains;

namespace Nop.Plugin.Widgets.Map.Services
{
    public class AddressGeolocationService
    {
        private readonly IRepository<Geolocation> _repository;

        public AddressGeolocationService(IRepository<Geolocation> repository)
        {
            _repository = repository;
        }

        public async Task AddGeolocationAsync(Geolocation geolocation)
        {
            await _repository.InsertAsync(geolocation);
        }

        public async Task UpdateGeolocationAsync(Geolocation geolocation)
        {
            await _repository.InsertAsync(geolocation);
        }

        public async Task DeleteGeolocationAsync(int? id)
        {
            if (id != null)
            {
                var location = await _repository.GetByIdAsync(id);
                await _repository.DeleteAsync(location);
            }
        }
        public async Task<Geolocation> GetGeolocationAsync(int? id)
        {
            if (id != null)
            {
                return await _repository.GetByIdAsync(id);
            }
            return null;
        }
    }
}
