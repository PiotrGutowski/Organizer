namespace Organizer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPhone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendPhoneNumber",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false),
                        FrinedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Friend", t => t.FrinedId, cascadeDelete: true)
                .Index(t => t.FrinedId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FriendPhoneNumber", "FrinedId", "dbo.Friend");
            DropIndex("dbo.FriendPhoneNumber", new[] { "FrinedId" });
            DropTable("dbo.FriendPhoneNumber");
        }
    }
}
