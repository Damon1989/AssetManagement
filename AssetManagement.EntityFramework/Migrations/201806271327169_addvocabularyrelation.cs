namespace AssetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvocabularyrelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.basic_VocabularyItems", "VocabularyId", c => c.String(maxLength: 128));
            CreateIndex("dbo.basic_VocabularyItems", "VocabularyId");
            AddForeignKey("dbo.basic_VocabularyItems", "VocabularyId", "dbo.basic_Vocabularies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.basic_VocabularyItems", "VocabularyId", "dbo.basic_Vocabularies");
            DropIndex("dbo.basic_VocabularyItems", new[] { "VocabularyId" });
            DropColumn("dbo.basic_VocabularyItems", "VocabularyId");
        }
    }
}
