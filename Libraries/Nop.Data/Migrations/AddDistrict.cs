using FluentMigrator;
using Nop.Core.Domain.Directory;

namespace Nop.Data.Migrations
{
    [NopMigration("2021/06/29 11:40:09:1647931")]
    public class AddDistrict : AutoReversingMigration
    {
        #region Methods

        public override void Up()
        {
            Create.Table(nameof(District))
              .WithColumn(nameof(District.Id)).AsInt32().PrimaryKey()
              .WithColumn(nameof(District.Name)).AsString(200).NotNullable()
              .WithColumn(nameof(City.Published)).AsBoolean()
              .WithColumn(nameof(City.DisplayOrder)).AsInt32()
              .WithColumn(nameof(District.CityId)).AsInt32().ForeignKey(nameof(City),nameof(City.Id));
        }

        #endregion
    }
}
