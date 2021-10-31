namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RAZREDI : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PredmetModels", "Razred", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PredmetModels", "Razred");
        }
    }
}
