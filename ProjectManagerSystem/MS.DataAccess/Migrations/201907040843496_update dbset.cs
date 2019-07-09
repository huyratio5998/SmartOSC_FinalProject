namespace MS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedbset : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsersProjects", newName: "ProjectAspNetUsers");
            RenameColumn(table: "dbo.ProjectAspNetUsers", name: "AspNetUsers_Id", newName: "AspNetUser_Id");
            RenameIndex(table: "dbo.ProjectAspNetUsers", name: "IX_AspNetUsers_Id", newName: "IX_AspNetUser_Id");
            DropPrimaryKey("dbo.ProjectAspNetUsers");
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ProjectAspNetUsers", new[] { "Project_Id", "AspNetUser_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProjectAspNetUsers");
            DropColumn("dbo.AspNetRoles", "Discriminator");
            AddPrimaryKey("dbo.ProjectAspNetUsers", new[] { "AspNetUsers_Id", "Project_Id" });
            RenameIndex(table: "dbo.ProjectAspNetUsers", name: "IX_AspNetUser_Id", newName: "IX_AspNetUsers_Id");
            RenameColumn(table: "dbo.ProjectAspNetUsers", name: "AspNetUser_Id", newName: "AspNetUsers_Id");
            RenameTable(name: "dbo.ProjectAspNetUsers", newName: "AspNetUsersProjects");
        }
    }
}
