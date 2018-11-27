namespace TravelDetroit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserProfiles", name: "User_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.UserProfiles", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            DropColumn("dbo.UserProfiles", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "Email", c => c.String());
            RenameIndex(table: "dbo.UserProfiles", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.UserProfiles", name: "ApplicationUser_Id", newName: "User_Id");
        }
    }
}
