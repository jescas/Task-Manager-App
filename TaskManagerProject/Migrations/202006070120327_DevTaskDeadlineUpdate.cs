namespace TaskManagerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DevTaskDeadlineUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DevTasks", "Deadline", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DevTasks", "Deadline", c => c.DateTime(nullable: false));
        }
    }
}
