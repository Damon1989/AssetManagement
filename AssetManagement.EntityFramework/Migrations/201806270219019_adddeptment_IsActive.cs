namespace AssetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddeptment_IsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.basic_Departments", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.basic_Departments", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.basic_Departments", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.basic_Departments", "IsActive");
        }
    }
}
