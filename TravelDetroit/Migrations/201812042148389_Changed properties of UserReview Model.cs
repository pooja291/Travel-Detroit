namespace TravelDetroit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedpropertiesofUserReviewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserReviews", "Location_Id", c => c.Int());
            AddColumn("dbo.UserReviews", "UserProfile_Id", c => c.Int());
            CreateIndex("dbo.UserReviews", "Location_Id");
            CreateIndex("dbo.UserReviews", "UserProfile_Id");
            AddForeignKey("dbo.UserReviews", "Location_Id", "dbo.Locations", "Id");
            AddForeignKey("dbo.UserReviews", "UserProfile_Id", "dbo.UserProfiles", "Id");
            DropColumn("dbo.UserReviews", "User");
            DropColumn("dbo.UserReviews", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserReviews", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.UserReviews", "User", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserReviews", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.UserReviews", "Location_Id", "dbo.Locations");
            DropIndex("dbo.UserReviews", new[] { "UserProfile_Id" });
            DropIndex("dbo.UserReviews", new[] { "Location_Id" });
            DropColumn("dbo.UserReviews", "UserProfile_Id");
            DropColumn("dbo.UserReviews", "Location_Id");
        }
    }
}
