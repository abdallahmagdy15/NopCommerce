using Nop.Core;

namespace Nop.Plugin.Widgets.Map.Domains
{
    public class Geolocation : BaseEntity
    {
        public decimal Latitude { get; set; }
        public decimal  Longitude { get; set; }

    }
}
