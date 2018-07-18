namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUsersAndExpressions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MathExpressions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Expression = c.String(),
                        ArrivedAt = c.DateTime(nullable: false),
                        ExitedAt = c.DateTime(nullable: false),
                        IsSuccessful = c.Boolean(nullable: false),
                        Owner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Owner_Id, cascadeDelete: true)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MathExpressions", "Owner_Id", "dbo.Users");
            DropIndex("dbo.MathExpressions", new[] { "Owner_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.MathExpressions");
        }
    }
}
