namespace TravelDetroit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserReviewModel : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.UserProfile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserReviews", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.UserReviews", "Location_Id", "dbo.Locations");
            DropIndex("dbo.UserReviews", new[] { "UserProfile_Id" });
            DropIndex("dbo.UserReviews", new[] { "Location_Id" });
            DropTable("dbo.UserReviews");
        }
    }
}
