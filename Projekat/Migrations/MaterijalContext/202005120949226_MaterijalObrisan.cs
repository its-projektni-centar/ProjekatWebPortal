namespace Projekat.Migrations.MaterijalContext
{
    using System.Data.Entity.Migrations;

    public partial class MaterijalObrisan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaterijalModels", "Obrisan", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.MaterijalModels", "Obrisan");
        }
    }
}