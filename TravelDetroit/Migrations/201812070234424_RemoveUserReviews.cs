namespace TravelDetroit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserReviews : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserReviews", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.UserReviews", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.UserReviews", new[] { "Location_Id" });
            DropIndex("dbo.UserReviews", new[] { "UserProfile_Id" });
            DropTable("dbo.UserReviews");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Review = c.String(),
                        Location_Id = c.Int(),
                        UserProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserReviews", "UserProfile_Id");
            CreateIndex("dbo.UserReviews", "Location_Id");
            AddForeignKey("dbo.UserReviews", "UserProfile_Id", "dbo.UserProfiles", "Id");
            AddForeignKey("dbo.UserReviews", "Location_Id", "dbo.Locations", "Id");
        }
    }
}
