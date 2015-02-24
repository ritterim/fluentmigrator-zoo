using FluentMigrator;

namespace Zoo.Models.Migrations
{
    [Migration(1424798531)]
    public class Create_KeeperEnclosures : Migration
    {
        public override void Up()
        {
            Create.Table("KeeperEnclosures")
                .WithColumn("KeeperId").AsInt32().PrimaryKey()
                    .ForeignKey("Keepers_FK", "Keepers", "Id")
                .WithColumn("EnclosureId").AsInt32().PrimaryKey()
                    .ForeignKey("Enclosures_FK", "Enclosures", "Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("Keepers_FK");
            Delete.ForeignKey("Enclosures_FK");

            Delete.Table("KeeperEnclosures");
        }
    }
}