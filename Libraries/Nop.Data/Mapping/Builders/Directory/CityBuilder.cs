using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Directory;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Directory
{
    /// <summary>
    /// Represents a city entity builder
    /// </summary>
    public partial class CityBuilder : NopEntityBuilder<City>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(City.Name)).AsString(100).NotNullable()
                .WithColumn(nameof(City.Abbreviation)).AsString(100).Nullable()
                .WithColumn(nameof(City.StateProvinceId)).AsInt32().ForeignKey<StateProvince>();
        }

        #endregion
    }
}