using FluentMigrator;

namespace Zoo.Models.Migrations
{
    [Migration(1424798908)]
    public class Add_EnclosureId_To_Animal : Migration
    {
        public override void Up()
        {
            Create.Column("EnclosureId").OnTable("Animals").AsInt32()
                .ForeignKey("Animal_Enclosure_FK", "Enclosures", "Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("Enclosure_FK");
            Delete.Column("EnclosureId");
        }
    }
}