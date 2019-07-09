namespace MS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateautomapping : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId);
            
            AlterColumn("dbo.Projects", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectMembers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectMembers", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectMembers", new[] { "ProjectId" });
            DropIndex("dbo.ProjectMembers", new[] { "UserId" });
            AlterColumn("dbo.Projects", "UserId", c => c.Int(nullable: false));
            DropTable("dbo.ProjectMembers");
        }
    }
}
