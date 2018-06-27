namespace AssetManagement.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class addvocabulary : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.basic_Vocabularies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Code = c.String(),
                        Name = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.basic_VocabularyItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Code = c.String(),
                        Name = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModifierUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        ExtensionData = c.String(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_VocabularyItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.basic_VocabularyItems",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_VocabularyItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.basic_Vocabularies");
        }
    }
}
