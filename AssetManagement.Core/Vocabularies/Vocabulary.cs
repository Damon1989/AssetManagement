using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Json;

namespace AssetManagement.Vocabularies
{
    public class Vocabulary : Entity<string>, IHasCreationTime
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual IEnumerable<VocabularyItem> Items { get; set; }

        public Vocabulary()
        {
            Id = Guid.NewGuid().ToString().Replace("-", "").ToLower();
            CreationTime = DateTime.Now;
        }

        public void Add(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }

    public class VocabularyItem : Entity<string>, IFullAudited, IExtendableObject
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }

        public string ExtensionData { get; set; }

        public string VocabularyId { get; set; }

        [ForeignKey("VocabularyId")]
        public virtual Vocabulary Vocabulary { get; set; }

        public VocabularyItem()
        {
            Id = Guid.NewGuid().ToString().Replace("-", "").ToLower();
        }

        public VocabularyItem(object data, string vocabularyId)
        {
            Id = Guid.NewGuid().ToString().Replace("-", "").ToLower();
            ExtensionData = data.ToJsonString(true);
            VocabularyId = vocabularyId;
        }

        public void Add(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}