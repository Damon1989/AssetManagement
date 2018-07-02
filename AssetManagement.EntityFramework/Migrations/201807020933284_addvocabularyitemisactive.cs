namespace AssetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvocabularyitemisactive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.basic_VocabularyItems", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.basic_VocabularyItems", "IsActive");
        }
    }
}
