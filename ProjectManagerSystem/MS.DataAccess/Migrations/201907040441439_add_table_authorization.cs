namespace MS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table_authorization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Functions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        URL = c.String(),
                        ParentId = c.String(),
                        IconCss = c.String(),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.String(maxLength: 128),
                        FunctionID = c.Int(nullable: false),
                        CanRead = c.Boolean(nullable: false),
                        CanCreate = c.Boolean(nullable: false),
                        CanUpdate = c.Boolean(nullable: false),
                        CanDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Functions", t => t.FunctionID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.FunctionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permissions", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Permissions", "FunctionID", "dbo.Functions");
            DropIndex("dbo.Permissions", new[] { "FunctionID" });
            DropIndex("dbo.Permissions", new[] { "RoleId" });
            DropTable("dbo.Permissions");
            DropTable("dbo.Functions");
        }
    }
}
