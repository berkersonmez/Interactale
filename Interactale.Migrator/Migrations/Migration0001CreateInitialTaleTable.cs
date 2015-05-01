using FluentMigrator;

namespace Interactale.Migrator.Migrations
{
    [Migration(1)]
    public class Migration0001CreateInitialTaleTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Tale")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(255).NotNullable();
        }
    }
}
