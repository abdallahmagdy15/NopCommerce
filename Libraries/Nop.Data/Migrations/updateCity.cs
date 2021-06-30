using FluentMigrator;
using Nop.Core.Domain.Directory;

namespace Nop.Data.Migrations
{
    [NopMigration("2021/06/29 11:52:09:1647931")]
    public class UpdateCity : AutoReversingMigration
    {
        #region Methods

        public override void Up()
        {
            Alter.Table(nameof(City))
              .AddColumn(nameof(City.Published)).AsBoolean().NotNullable()
              .AddColumn(nameof(City.DisplayOrder)).AsInt32().NotNullable();
        }

        #endregion
    }
}
