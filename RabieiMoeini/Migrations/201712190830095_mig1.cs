namespace RabieiMoeini.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Meeting.Attachment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeetingId = c.Int(nullable: false),
                        FileData = c.Binary(),
                        OriginalFileName = c.String(),
                        MimeType = c.String(),
                        FileSize = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Meeting.Meetings", t => t.MeetingId, cascadeDelete: true)
                .Index(t => t.MeetingId);
            
            CreateTable(
                "Meeting.Meetings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TItle = c.String(nullable: false, maxLength: 100),
                        Date = c.String(nullable: false, maxLength: 10),
                        StartTime = c.String(nullable: false, maxLength: 5),
                        EndTime = c.String(nullable: false, maxLength: 5),
                        Place = c.String(maxLength: 100),
                        Explain = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "People.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Family = c.String(nullable: false, maxLength: 50),
                        Post = c.String(maxLength: 200),
                        NationalCode = c.String(maxLength: 10),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organs",
                c => new
                    {
                        OrganId = c.Int(nullable: false, identity: true),
                        OrganName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.OrganId);
            
            CreateTable(
                "dbo.GuestMeetings",
                c => new
                    {
                        Guest_Id = c.Int(nullable: false),
                        Meeting_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guest_Id, t.Meeting_Id })
                .ForeignKey("People.Guest", t => t.Guest_Id, cascadeDelete: true)
                .ForeignKey("Meeting.Meetings", t => t.Meeting_Id, cascadeDelete: true)
                .Index(t => t.Guest_Id)
                .Index(t => t.Meeting_Id);
            
            CreateTable(
                "People.Guest",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MeetingId = c.Int(nullable: false),
                        In_Out = c.String(maxLength: 50),
                        OrganId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("People.Person", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "People.Indicator",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SessionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("People.Person", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "People.User",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 50),
                        PasswordHash = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("People.Person", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Username, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("People.User", "Id", "People.Person");
            DropForeignKey("People.Indicator", "Id", "People.Person");
            DropForeignKey("People.Guest", "Id", "People.Person");
            DropForeignKey("dbo.GuestMeetings", "Meeting_Id", "Meeting.Meetings");
            DropForeignKey("dbo.GuestMeetings", "Guest_Id", "People.Guest");
            DropForeignKey("Meeting.Attachment", "MeetingId", "Meeting.Meetings");
            DropIndex("People.User", new[] { "Username" });
            DropIndex("People.User", new[] { "Id" });
            DropIndex("People.Indicator", new[] { "Id" });
            DropIndex("People.Guest", new[] { "Id" });
            DropIndex("dbo.GuestMeetings", new[] { "Meeting_Id" });
            DropIndex("dbo.GuestMeetings", new[] { "Guest_Id" });
            DropIndex("Meeting.Attachment", new[] { "MeetingId" });
            DropTable("People.User");
            DropTable("People.Indicator");
            DropTable("People.Guest");
            DropTable("dbo.GuestMeetings");
            DropTable("dbo.Organs");
            DropTable("People.Person");
            DropTable("Meeting.Meetings");
            DropTable("Meeting.Attachment");
        }
    }
}
