using FluentMigrator;

namespace Zoo.Models.Migrations
{
    [Migration(1424798530)]
    public class Create_Keeper : Migration
    {
        public override void Up()
        {
            Create
                .Table("Keepers")
                .WithIdColumn()
                .WithColumn("FirstName").AsString()
                .WithColumn("LastName").AsString()
                .WithColumn("Birthday").AsDate();
        }

        public override void Down()
        {
            Delete.Table("Keepers");
        }
    }
}