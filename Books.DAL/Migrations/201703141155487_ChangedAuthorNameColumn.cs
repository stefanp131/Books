namespace Books.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAuthorNameColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "AuthorReaderCritic", c => c.String(maxLength: 50));
            DropColumn("dbo.Books", "AuthorName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "AuthorName", c => c.String(maxLength: 50));
            DropColumn("dbo.Books", "AuthorReaderCritic");
        }
    }
}
