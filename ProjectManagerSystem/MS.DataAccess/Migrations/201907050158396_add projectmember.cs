namespace MS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addprojectmember : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectAspNetUsers", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.ProjectAspNetUsers", "AspNetUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ProjectAspNetUsers", new[] { "Project_Id" });
            DropIndex("dbo.ProjectAspNetUsers", new[] { "AspNetUser_Id" });
            DropColumn("dbo.AspNetUsers", "ProjectId");
            DropColumn("dbo.Projects", "UserId");
            DropTable("dbo.ProjectAspNetUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProjectAspNetUsers",
                c => new
                    {
                        Project_Id = c.Int(nullable: false),
                        AspNetUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.AspNetUser_Id });
            
            AddColumn("dbo.Projects", "UserId", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "ProjectId", c => c.Int());
            CreateIndex("dbo.ProjectAspNetUsers", "AspNetUser_Id");
            CreateIndex("dbo.ProjectAspNetUsers", "Project_Id");
            AddForeignKey("dbo.ProjectAspNetUsers", "AspNetUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProjectAspNetUsers", "Project_Id", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
