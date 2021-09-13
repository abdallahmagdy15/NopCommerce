
namespace Nop.Core.PushNotifications
{
    public partial class ClientSubscription : BaseEntity
    {
        public string client { get; set; }
        public string endpoint { get; set; }
        public string p256dh { get; set; }
        public string auth { get; set; }
    }
}