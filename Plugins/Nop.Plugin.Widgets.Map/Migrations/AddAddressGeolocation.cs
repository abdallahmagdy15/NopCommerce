using FluentMigrator;
using Nop.Data.Migrations;
using Nop.Plugin.Widgets.Map.Domains;

namespace Nop.PluginWidgets.Map.Migrations
{
    [NopMigration("2021/06/27 12:00:00", "Nop.Plugin.Widgets.Map schema")]
    public class AddAddressGeolocation : AutoReversingMigration
    {
        private readonly IMigrationManager _migrationManager;

        public AddAddressGeolocation(IMigrationManager migrationManager)
        {
            _migrationManager = migrationManager;
        }

        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            _migrationManager.BuildTable<Geolocation>(Create);
        }
    }
}
