namespace TravelDetroit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToUserProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Name");
        }
    }
}
