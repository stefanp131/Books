namespace Books.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookNameForPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "BookName", c => c.String(maxLength: 50));
            AlterColumn("dbo.People", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Name", c => c.String());
            DropColumn("dbo.People", "BookName");
        }
    }
}
