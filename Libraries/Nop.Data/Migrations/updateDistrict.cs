using FluentMigrator;
using Nop.Core.Domain.Directory;

namespace Nop.Data.Migrations
{
    [NopMigration("2021/06/29 11:53:09:1647931")]
    public class UpdateDistrict : AutoReversingMigration
    {
        #region Methods

        public override void Up()
        {
            Alter.Table(nameof(District))
              .AddColumn(nameof(District.Published)).AsBoolean().NotNullable()
              .AddColumn(nameof(District.DisplayOrder)).AsInt32().NotNullable();
        }

        #endregion
    }
}
