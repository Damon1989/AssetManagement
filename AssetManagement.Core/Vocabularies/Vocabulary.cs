using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public VocabularyItem()
        {
            Id = Guid.NewGuid().ToString().Replace("-", "").ToLower();
        }
    }

    public class VocabularyItem<T> : VocabularyItem
    {
        public T Data { get; set; }

        public VocabularyItem()
        {
        }

        public VocabularyItem(T data)
        {
            Data = data;
            ExtensionData = data.ToJsonString(true);
        }

        public void Add(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}