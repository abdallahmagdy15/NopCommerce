using FluentMigrator;
using Nop.Core.Domain.Common;

namespace Nop.Data.Migrations
{
    [NopMigration("2021/06/30 11:58:09:1647931")]
    public class AddLatLongToAddress : AutoReversingMigration
    {
        #region Methods

        public override void Up()
        {
            Alter.Table(nameof(Address))
                .AddColumn(nameof(Address.Latitude)).AsDecimal().Nullable()
                .AddColumn(nameof(Address.Longitude)).AsDecimal().Nullable();

        }

        #endregion
    }
}
