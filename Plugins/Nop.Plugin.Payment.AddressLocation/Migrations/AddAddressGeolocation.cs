using FluentMigrator;
using Nop.Data.Migrations;
using Nop.Plugin.Payment.AddressGeolocation.Domains;

namespace Nop.Plugin.Payment.AddressGeolocation.Migrations
{
    [NopMigration("2021/06/27 12:00:00", "Nop.Plugin.Payment.AddressGeolocation schema")]
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
