namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMoviesTable : DbMigration
    {
        public override void Up()
        {
           Sql("Insert into Movies(Name, GenreId, ReleaseDate, DateAdded, NumberInStock) Values ('Hangover', 5, GETDATE(), GETDATE(), 5)");
           Sql("Insert into Movies(Name, GenreId, ReleaseDate, DateAdded, NumberInStock) Values ('Die Hard', 1, GETDATE(), GETDATE(), 5)");
           Sql("Insert into Movies(Name, GenreId, ReleaseDate, DateAdded, NumberInStock) Values ('The Terminator', 1, GETDATE(), GETDATE(), 33)");
           Sql("Insert into Movies(Name, GenreId, ReleaseDate, DateAdded, NumberInStock) Values ('Toy Story', 3, GETDATE(), GETDATE(), 33)");
           Sql("Insert into Movies(Name, GenreId, ReleaseDate, DateAdded, NumberInStock) Values ('Titanic', 4, GETDATE(), GETDATE(), 33)");
        }
        
        public override void Down()
        {
        }
    }
}
