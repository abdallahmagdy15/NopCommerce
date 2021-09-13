using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Polls;
using Nop.Core.PushNotifications;

namespace Nop.Services.PushNotifications
{
    public partial interface IClientSubscriptionService
    {
        public List<string> GetClientNames();
        public Task SaveSubscription(ClientSubscription clientSubscription);
        public ClientSubscription GetSubscription(string client);

    }
}