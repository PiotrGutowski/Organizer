namespace Organizer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMusicGenreFix : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Friend", name: "FavoriteHobbyId", newName: "FavoriteMusicGenreId");
            RenameIndex(table: "dbo.Friend", name: "IX_FavoriteHobbyId", newName: "IX_FavoriteMusicGenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Friend", name: "IX_FavoriteMusicGenreId", newName: "IX_FavoriteHobbyId");
            RenameColumn(table: "dbo.Friend", name: "FavoriteMusicGenreId", newName: "FavoriteHobbyId");
        }
    }
}
