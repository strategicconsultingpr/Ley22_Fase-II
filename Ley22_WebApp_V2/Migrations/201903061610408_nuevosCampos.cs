namespace Ley22_WebApp_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevosCampos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Active", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.AspNetUsers", "PasswordChanged", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PasswordChanged");
            DropColumn("dbo.AspNetUsers", "Active");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
