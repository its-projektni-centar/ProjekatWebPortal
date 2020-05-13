namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmeroviPoSkolama : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SmerPoSkolis",
                c => new
                    {
                        skolaId = c.Int(nullable: false),
                        smerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.skolaId, t.smerId })
                .ForeignKey("dbo.SkolaModels", t => t.skolaId, cascadeDelete: true)
                .ForeignKey("dbo.SmerModels", t => t.smerId, cascadeDelete: true)
                .Index(t => t.skolaId)
                .Index(t => t.smerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SmerPoSkolis", "smerId", "dbo.SmerModels");
            DropForeignKey("dbo.SmerPoSkolis", "skolaId", "dbo.SkolaModels");
            DropIndex("dbo.SmerPoSkolis", new[] { "smerId" });
            DropIndex("dbo.SmerPoSkolis", new[] { "skolaId" });
            DropTable("dbo.SmerPoSkolis");
        }
    }
}
