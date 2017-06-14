namespace DuckDuck.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upatedModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "Location", c => c.String());
            AddColumn("dbo.AspNetUsers", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Location");
            DropColumn("dbo.Rooms", "Location");
        }
    }
}
