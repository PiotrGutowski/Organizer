namespace Organizer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMusicGenre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavoriteMusicGenre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Friend", "FavoriteHobbyId", c => c.Int());
            CreateIndex("dbo.Friend", "FavoriteHobbyId");
            AddForeignKey("dbo.Friend", "FavoriteHobbyId", "dbo.FavoriteMusicGenre", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friend", "FavoriteHobbyId", "dbo.FavoriteMusicGenre");
            DropIndex("dbo.Friend", new[] { "FavoriteHobbyId" });
            DropColumn("dbo.Friend", "FavoriteHobbyId");
            DropTable("dbo.FavoriteMusicGenre");
        }
    }
}
