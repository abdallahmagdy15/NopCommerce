using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Data;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Data;
using Nop.Plugin.Payment.AddressGeolocation.Domains;

namespace Nop.Plugin.Payment.AddressGeolocation.Services
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
