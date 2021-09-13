using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Configuration
{
    public class VAPID
    {
        public string subject { get; set; }
        public string  publicKey { get; set; }
        public string privateKey { get; set; }

    }
}
