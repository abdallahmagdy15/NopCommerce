using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Common
{
    class AddressLocation: BaseEntity
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
