namespace TravelDetroit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagsAddedToLocationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "Tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "Tags");
        }
    }
}
