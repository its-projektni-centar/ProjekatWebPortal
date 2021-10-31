namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForumMessage1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Forum_Message",
                c => new
                {
                    Id_message = c.Int(nullable: false, identity: true),
                    messagePost = c.String(),
                    messageDate = c.DateTime(defaultValue: DateTime.Now),
                    Id_post = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id_message)
                .ForeignKey("dbo.Forum_Posts", t => t.Id_post, cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Id_post", "dbo.Forum_Message");
            DropTable("dbo.Forum_Message");
        }
    }
}
