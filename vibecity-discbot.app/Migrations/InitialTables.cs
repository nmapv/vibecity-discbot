using FluentMigrator;

namespace vibecity_discbot.app.Migrations
{
    [Migration(1)]
    public class InitialTables : Migration
    {
        public override void Down()
        {
            Delete.Table("User");
            Delete.Table("Point");
        }

        public override void Up()
        {
            Create.Table("User")
                .WithColumn("id").AsInt64().NotNullable().PrimaryKey()
                .WithColumn("fac").AsString(200).Nullable()
                .WithColumn("name").AsString(200).NotNullable().Unique();

            Create.Table("Point")
                .WithColumn("id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("user_id").AsInt64().NotNullable().Unique()
                .WithColumn("started").AsDateTime().NotNullable();
        }
    }
}
