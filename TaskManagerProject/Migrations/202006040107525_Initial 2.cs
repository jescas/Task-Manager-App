namespace TaskManagerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
          //  DropForeignKey("dbo.Notes", "ProjectId", "dbo.Projects");
           // DropIndex("dbo.Notes", new[] { "ProjectId" });
           // DropColumn("dbo.Notes", "ProjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Notes", "ProjectId");
            AddForeignKey("dbo.Notes", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
