namespace Books.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRestrictionsForBookEntity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.Books", "AuthorName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Books", "Category", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Category", c => c.String(maxLength: 256));
            AlterColumn("dbo.Books", "AuthorName", c => c.String(maxLength: 256));
            AlterColumn("dbo.Books", "Title", c => c.String(maxLength: 256));
        }
    }
}
