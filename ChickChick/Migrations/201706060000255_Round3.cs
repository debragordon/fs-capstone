namespace ChickChick.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Round3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomName = c.String(),
                        OccupancyMax = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.WaitingStudents",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .ForeignKey("dbo.Students", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Room_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WaitingStudents", "Id", "dbo.Students");
            DropForeignKey("dbo.WaitingStudents", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Students", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.WaitingStudents", new[] { "Room_Id" });
            DropIndex("dbo.WaitingStudents", new[] { "Id" });
            DropIndex("dbo.Students", new[] { "Room_Id" });
            DropTable("dbo.WaitingStudents");
            DropTable("dbo.Students");
            DropTable("dbo.Rooms");
        }
    }
}
