namespace AssetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addassetcode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.b_Assets", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.b_Assets", "Code");
        }
    }
}
