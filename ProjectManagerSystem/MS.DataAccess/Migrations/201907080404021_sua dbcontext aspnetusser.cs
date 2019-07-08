namespace MS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suadbcontextaspnetusser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "FullName", c => c.String(nullable: false, maxLength: 32));
            DropColumn("dbo.AspNetUsers", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "FullName", c => c.String(maxLength: 32));
        }
    }
}
