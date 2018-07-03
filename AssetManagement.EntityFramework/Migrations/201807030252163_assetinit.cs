namespace AssetManagement.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class assetinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.b_Assets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionTime = c.DateTime(),
                        DeleterUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Asset_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.b_Assets",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Asset_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
