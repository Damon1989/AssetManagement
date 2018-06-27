using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace AssetManagement.Depts
{
    public class Deptment : Entity<string>, IFullAudited, IPassivable
    {
        public virtual long? CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
        public virtual long? LastModifierUserId { get; set; }
        public virtual DateTime? LastModificationTime { get; set; }
        public virtual long? DeleterUserId { get; set; }
        public virtual DateTime? DeletionTime { get; set; }
        public virtual bool IsDeleted { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }

        public bool IsActive { get; set; }

        public Deptment()
        {
            Id = Guid.NewGuid().ToString().Replace("-", "").ToLower();
            IsActive = true;
        }

        public void Add(string code, string name, string parentId)
        {
            Code = code;
            Name = name;
            ParentId = parentId;
        }

        public void Edit(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public void Enabled()
        {
            IsActive = true;
        }

        public void Disabled()
        {
            IsActive = false;
        }
    }
}