using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Directory
{
    public class District: BaseEntity
    {
        public int CityId { get; set; }
        public string Name { get; set; }

    }
}
