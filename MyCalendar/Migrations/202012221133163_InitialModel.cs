namespace MyCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        Calendar_id = c.Int(nullable: false, identity: true),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Event_id = c.Int(),
                        Task_id = c.Int(),
                    })
                .PrimaryKey(t => t.Calendar_id)
                .ForeignKey("dbo.Events", t => t.Event_id)
                .ForeignKey("dbo.Tasks", t => t.Task_id)
                .Index(t => t.Event_id)
                .Index(t => t.Task_id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Event_id = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        TherneColor = c.String(nullable: false),
                        IsFullDay = c.Boolean(nullable: false),
                        Org_id = c.Int(),
                        Notify_id = c.Int(),
                    })
                .PrimaryKey(t => t.Event_id)
                .ForeignKey("dbo.Notifications", t => t.Notify_id)
                .ForeignKey("dbo.Organizations", t => t.Org_id)
                .Index(t => t.Org_id)
                .Index(t => t.Notify_id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Notify_Id = c.Int(nullable: false, identity: true),
                        Notify_date = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Notify_Id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Org_id = c.Int(nullable: false, identity: true),
                        Org_name = c.String(nullable: false),
                        Org_information = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Name_organizer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Org_id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Task_id = c.Int(nullable: false, identity: true),
                        Task_name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Deadline = c.String(nullable: false),
                        ImagePath = c.String(),
                        Completed = c.Boolean(nullable: false),
                        Category_Id = c.Int(),
                        Notify_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Task_id)
                .ForeignKey("dbo.CategoryTasks", t => t.Category_Id)
                .ForeignKey("dbo.Notifications", t => t.Notify_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Notify_Id);
            
            CreateTable(
                "dbo.CategoryTasks",
                c => new
                    {
                        Category_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Category_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Event_id = c.Int(),
                        Task_id = c.Int(),
                        Calendar_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Calendars", t => t.Calendar_id)
                .ForeignKey("dbo.Events", t => t.Event_id)
                .ForeignKey("dbo.Tasks", t => t.Task_id)
                .Index(t => t.Event_id)
                .Index(t => t.Task_id)
                .Index(t => t.Calendar_id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Users", "Task_id", "dbo.Tasks");
            DropForeignKey("dbo.Users", "Event_id", "dbo.Events");
            DropForeignKey("dbo.Users", "Calendar_id", "dbo.Calendars");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Calendars", "Task_id", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "Notify_Id", "dbo.Notifications");
            DropForeignKey("dbo.Tasks", "Category_Id", "dbo.CategoryTasks");
            DropForeignKey("dbo.Calendars", "Event_id", "dbo.Events");
            DropForeignKey("dbo.Events", "Org_id", "dbo.Organizations");
            DropForeignKey("dbo.Events", "Notify_id", "dbo.Notifications");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Users", new[] { "Calendar_id" });
            DropIndex("dbo.Users", new[] { "Task_id" });
            DropIndex("dbo.Users", new[] { "Event_id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Tasks", new[] { "Notify_Id" });
            DropIndex("dbo.Tasks", new[] { "Category_Id" });
            DropIndex("dbo.Events", new[] { "Notify_id" });
            DropIndex("dbo.Events", new[] { "Org_id" });
            DropIndex("dbo.Calendars", new[] { "Task_id" });
            DropIndex("dbo.Calendars", new[] { "Event_id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Users");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.CategoryTasks");
            DropTable("dbo.Tasks");
            DropTable("dbo.Organizations");
            DropTable("dbo.Notifications");
            DropTable("dbo.Events");
            DropTable("dbo.Calendars");
        }
    }
}
