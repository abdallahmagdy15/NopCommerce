using FluentMigrator;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;

namespace Nop.Data.Migrations
{
    [NopMigration("2021/06/29 11:50:09:1647931")]
    public class AddCityDistrictToAddress : AutoReversingMigration
    {
        #region Methods

        public override void Up()
        {
            Alter.Table(nameof(Address))
                .AddColumn(nameof(Address.CityId)).AsInt32().Nullable().ForeignKey(nameof(City), nameof(City.Id))
                .AddColumn(nameof(Address.DistrictId)).AsInt32().Nullable().ForeignKey(nameof(District), nameof(District.Id));

        }

        #endregion
    }
}
