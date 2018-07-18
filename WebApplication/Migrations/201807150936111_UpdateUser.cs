namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String(maxLength: 32));
            AddColumn("dbo.Users", "Password", c => c.String());
            Sql (@"CREATE UNIQUE NONCLUSTERED INDEX IX_UserName ON dbo.Users (UserName ASC) WHERE UserName IS NOT NULL;");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", "IX_UserName");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "UserName");
        }
    }
}
