namespace Books.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRestrictionsForBookEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 256),
                        AuthorName = c.String(maxLength: 256),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(maxLength: 256),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Person_Id", "dbo.People");
            DropIndex("dbo.Books", new[] { "Person_Id" });
            DropTable("dbo.People");
            DropTable("dbo.Books");
        }
    }
}
