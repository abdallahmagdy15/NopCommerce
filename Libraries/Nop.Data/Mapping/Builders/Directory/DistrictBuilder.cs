using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Directory;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Directory
{
    /// <summary>
    /// Represents a city entity builder
    /// </summary>
    public partial class DistrictBuilder : NopEntityBuilder<District>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(District.Name)).AsString(100).NotNullable()
                .WithColumn(nameof(District.CityId)).AsInt32().ForeignKey<City>();
        }

        #endregion
    }
}