namespace FullstackPluralsightProjectToLearn.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenresTAble : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (Id, Name) Values (1, 'Jazz')");
            Sql("Insert into Genres (Id, Name) Values (2, 'Blues')");
            Sql("Insert into Genres (Id, Name) Values (3, 'Rock')");
            Sql("Insert into Genres (Id, Name) Values (4, 'Country')");
        }
        
        public override void Down()
        {
            Sql("delete from Genres where id in (1,2,3,4)");
        }
    }
}
