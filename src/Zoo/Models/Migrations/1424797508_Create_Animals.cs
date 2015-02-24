using FluentMigrator;

namespace Zoo.Models.Migrations
{
    [Migration(1424797508)]
    public class Create_Animals : Migration
    {
        public override void Up()
        {
            Create
                .Table("Animals")
                .WithIdColumn()
                .WithColumn("Name").AsString()
                .WithColumn("Species").AsString()
                .WithColumn("Birthday").AsDate();
        }

        public override void Down()
        {
            Delete.Table("Animals");
        }
    }
}