namespace ChickChick.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "SubmissionDate", c => c.DateTime());
            AlterColumn("dbo.Students", "StartDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "SubmissionDate", c => c.DateTime(nullable: false));
        }
    }
}
