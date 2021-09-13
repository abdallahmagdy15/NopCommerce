using Microsoft.AspNetCore.Mvc;
using Nop.Core.Configuration;
using Nop.Core.PushNotifications;
using Nop.Services.PushNotifications;
using System;
using WebPush;
namespace Nop.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        private readonly AppSettings config;
        private readonly IClientSubscriptionService clientSubscriptionService;

        public HomeController(AppSettings config, IClientSubscriptionService clientSubscriptionService)
        {
            this.config = config;
            this.clientSubscriptionService = clientSubscriptionService;
        }
        public virtual IActionResult Index()
        {
            ViewBag.applicationServerKey = config.VAPID.publicKey;
            return View();
        }
        [HttpPost]
        public virtual IActionResult Index(ClientSubscription clientSubscription)
        {
            if (clientSubscription.client == null)
            {
                return BadRequest("No Client Name parsed.");
            }
            if (clientSubscriptionService.GetClientNames().Contains(clientSubscription.client))
            {
                return BadRequest("Client Name already used.");
            }
            clientSubscriptionService.SaveSubscription(clientSubscription);
            ViewBag.applicationServerKey = config.VAPID?.publicKey;

            return View("Notify", clientSubscriptionService.GetClientNames());
        }
        public IActionResult Notify()
        {
            return View(clientSubscriptionService.GetClientNames());
        }
        [HttpPost]
        public IActionResult Notify(string message, string client)
        {
            if (client == null)
            {
                return BadRequest("No Client Name parsed.");
            }
            var clientSub  = clientSubscriptionService.GetSubscription(client);
            PushSubscription subscription = new PushSubscription(clientSub.endpoint,clientSub.p256dh , clientSub.auth) ;
            if (subscription == null)
            {
                return BadRequest("Client was not found");
            }

            var VAPID = config.VAPID;
            var vapidDetails = new VapidDetails(VAPID?.subject, VAPID?.publicKey, VAPID?.privateKey);
            var webPushClient = new WebPushClient();
            try
            {
                webPushClient.SendNotification(subscription, message, vapidDetails);
            }
            catch (Exception exception)
            {
                // Log error
            }

            return View(clientSubscriptionService.GetClientNames());
        }
    }
}