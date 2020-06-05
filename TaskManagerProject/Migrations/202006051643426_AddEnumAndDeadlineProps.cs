namespace TaskManagerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnumAndDeadlineProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DevTasks", "Deadline", c => c.DateTime(nullable: true));
            AddColumn("dbo.DevTasks", "Priority", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "Deadline", c => c.DateTime(nullable: true));
            AddColumn("dbo.Projects", "Priority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Priority");
            DropColumn("dbo.Projects", "Deadline");
            DropColumn("dbo.DevTasks", "Priority");
            DropColumn("dbo.DevTasks", "Deadline");
        }
    }
}
