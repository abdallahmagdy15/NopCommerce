using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;

namespace Nop.Plugin.Payment.AddressGeolocation.Domains
{
    public class Geolocation : BaseEntity
    {
        public decimal Latitude { get; set; }
        public decimal  Longitude { get; set; }

    }
}
