namespace TravelDetroit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFavoriteLocationsToUserProfile : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserProfiles", "Name");
            DropColumn("dbo.UserProfiles", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "Password", c => c.String(nullable: false));
            AddColumn("dbo.UserProfiles", "Name", c => c.String(nullable: false));
        }
    }
}
