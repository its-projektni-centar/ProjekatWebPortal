namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PredlozeniModul : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GlobalniZahteviModels", "predlozeniModul", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GlobalniZahteviModels", "predlozeniModul");
        }
    }
}
