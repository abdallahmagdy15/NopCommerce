

using Nop.Core.PushNotifications;
using Nop.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nop.Services.PushNotifications
{
    /// <summary>
    /// Poll service
    /// </summary>
    public partial class ClientSubscriptionService : IClientSubscriptionService
    {
        private readonly IRepository<ClientSubscription> _clientSubscriptionRepository;

        public ClientSubscriptionService(IRepository<ClientSubscription> repository)
        {
            _clientSubscriptionRepository = repository;
        }
        public List<string> GetClientNames()
        {

            return _clientSubscriptionRepository.GetAll().Select(x => x.client).ToList();
        }

        public virtual async Task SaveSubscription(ClientSubscription clientSubscription)
        {
            if (clientSubscription != null)
            {
                await _clientSubscriptionRepository.InsertAsync(clientSubscription);
            }
        }

        public ClientSubscription GetSubscription(string client)
        {
            var query = from c in _clientSubscriptionRepository.Table
                        where c.client == client
                        select c;
            return query.FirstOrDefault();
        }
    }
}