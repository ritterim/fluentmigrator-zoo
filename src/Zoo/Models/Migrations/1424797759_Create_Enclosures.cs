using FluentMigrator;

namespace Zoo.Models.Migrations
{
    [Migration(1424797759)]
    public class Create_Enclosures : Migration
    {
        public override void Up()
        {
            Create
                .Table("Enclosures")
                .WithIdColumn()
                .WithColumn("Name").AsString()
                .WithColumn("Location").AsString()
                .WithColumn("Environment").AsString();
        }

        public override void Down()
        {
            Delete.Table("Enclosures");
        }
    }
}