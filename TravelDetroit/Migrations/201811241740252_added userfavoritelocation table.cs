namespace TravelDetroit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduserfavoritelocationtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "PlaceId", c => c.String(nullable: false));
            AddColumn("dbo.Locations", "Address", c => c.String());
            AddColumn("dbo.UserProfiles", "Email", c => c.String());
            DropColumn("dbo.Locations", "Url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Url", c => c.String(nullable: false));
            DropColumn("dbo.UserProfiles", "Email");
            DropColumn("dbo.Locations", "Address");
            DropColumn("dbo.Locations", "PlaceId");
        }
    }
}
