using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Directory
{
    public class District: BaseEntity, ILocalizedEntity
    {
        public int CityId { get; set; }
        public string Name { get; set; }

    }
}
