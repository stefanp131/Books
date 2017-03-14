namespace Books.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RechangedBackToAuthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Author", c => c.String(maxLength: 50));
            DropColumn("dbo.Books", "AuthorReaderCritic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "AuthorReaderCritic", c => c.String(maxLength: 50));
            DropColumn("dbo.Books", "Author");
        }
    }
}
