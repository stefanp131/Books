namespace Books.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRelationshipBetweenEntitiesToManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Person_Id", "dbo.People");
            DropIndex("dbo.Books", new[] { "Person_Id" });
            CreateTable(
                "dbo.PersonBooks",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Book_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Book_Id);
            
            DropColumn("dbo.Books", "Person_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Person_Id", c => c.Int());
            DropForeignKey("dbo.PersonBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.PersonBooks", "Person_Id", "dbo.People");
            DropIndex("dbo.PersonBooks", new[] { "Book_Id" });
            DropIndex("dbo.PersonBooks", new[] { "Person_Id" });
            DropTable("dbo.PersonBooks");
            CreateIndex("dbo.Books", "Person_Id");
            AddForeignKey("dbo.Books", "Person_Id", "dbo.People", "Id");
        }
    }
}
