namespace TaskManagerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeprojectdeadlinenullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Deadline", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Deadline", c => c.DateTime(nullable: false));
        }
    }
}
