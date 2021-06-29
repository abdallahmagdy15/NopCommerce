using FluentMigrator;
using Nop.Core.Domain.Directory;

namespace Nop.Data.Migrations
{
    [NopMigration("2021/06/29 11:37:09:1647931")]
    public class AddCity : AutoReversingMigration
    {
        #region Methods

        public override void Up()
        {
            Create.Table(nameof(City))
              .WithColumn(nameof(City.Id)).AsInt32().PrimaryKey()
              .WithColumn(nameof(City.Name)).AsString(100).NotNullable()
              .WithColumn(nameof(City.Abbreviation)).AsString(100).Nullable()
              .WithColumn(nameof(City.Published)).AsBoolean()
              .WithColumn(nameof(City.DisplayOrder)).AsInt32()
              .WithColumn(nameof(City.StateProvinceId)).AsInt32().ForeignKey(nameof(StateProvince),nameof(StateProvince.Id));
        }

        #endregion
    }
}
