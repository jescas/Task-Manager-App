namespace TaskManagerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemakeNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notifications", "DevTaskId", "dbo.DevTasks");
            DropForeignKey("dbo.Notifications", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Notifications", new[] { "DevTaskId" });
            DropIndex("dbo.Notifications", new[] { "ProjectId" });
            AlterColumn("dbo.Notifications", "DevTaskId", c => c.Int());
            AlterColumn("dbo.Notifications", "ProjectId", c => c.Int());
            CreateIndex("dbo.Notifications", "DevTaskId");
            CreateIndex("dbo.Notifications", "ProjectId");
            AddForeignKey("dbo.Notifications", "DevTaskId", "dbo.DevTasks", "Id");
            AddForeignKey("dbo.Notifications", "ProjectId", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Notifications", "DevTaskId", "dbo.DevTasks");
            DropIndex("dbo.Notifications", new[] { "ProjectId" });
            DropIndex("dbo.Notifications", new[] { "DevTaskId" });
            AlterColumn("dbo.Notifications", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Notifications", "DevTaskId", c => c.Int(nullable: false));
            CreateIndex("dbo.Notifications", "ProjectId");
            CreateIndex("dbo.Notifications", "DevTaskId");
            AddForeignKey("dbo.Notifications", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Notifications", "DevTaskId", "dbo.DevTasks", "Id", cascadeDelete: true);
        }
    }
}
