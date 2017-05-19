namespace FullstackPluralsightProjectToLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTAble1 : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres ( Name) values ( 'Rock')");
            Sql("Insert into Genres ( Name) values ('Jazz')");
            Sql("Insert into Genres ( Name) values ( 'Blues')");
            Sql("Insert into Genres ( Name) values ('Country')");
        }
        
        public override void Down()
        {
        }
    }
}
