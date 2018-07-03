using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace AssetManagement.Assets
{
    public class Asset : Entity<string>, IFullAudited
    {
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
        public string Code { get; set; }
    }
}