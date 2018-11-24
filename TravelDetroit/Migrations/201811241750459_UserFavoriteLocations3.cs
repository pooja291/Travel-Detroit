namespace TravelDetroit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFavoriteLocations3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfileLocations",
                c => new
                    {
                        UserProfile_Id = c.Int(nullable: false),
                        Location_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserProfile_Id, t.Location_Id })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.Location_Id, cascadeDelete: true)
                .Index(t => t.UserProfile_Id)
                .Index(t => t.Location_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfileLocations", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.UserProfileLocations", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.UserProfileLocations", new[] { "Location_Id" });
            DropIndex("dbo.UserProfileLocations", new[] { "UserProfile_Id" });
            DropTable("dbo.UserProfileLocations");
        }
    }
}
