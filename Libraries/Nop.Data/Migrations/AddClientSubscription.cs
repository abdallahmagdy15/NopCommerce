using FluentMigrator;
using Nop.Core.PushNotifications;

namespace Nop.Data.Migrations
{
    [NopMigration("2021/09/05 11:37:09:1647931")]
    public class AddClientSubscription : AutoReversingMigration
    {
        #region Methods

        public override void Up()
        {
            Create.Table(nameof(ClientSubscription))
                .WithColumn(nameof(ClientSubscription.Id)).AsInt32().PrimaryKey()
                .WithColumn(nameof(ClientSubscription.client)).AsString().Nullable()
                .WithColumn(nameof(ClientSubscription.endpoint)).AsString().Nullable()
                .WithColumn(nameof(ClientSubscription.p256dh)).AsString().Nullable()
                .WithColumn(nameof(ClientSubscription.auth)).AsString().Nullable();
        }
        #endregion
    }
}
