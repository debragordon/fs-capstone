namespace ChickChick.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Rate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Rate");
        }
    }
}
