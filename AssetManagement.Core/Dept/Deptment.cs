using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace AssetManagement.Dept
{
    public class Deptment : Entity<string>, IFullAudited
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
        public CommonStatus Status { get; private set; }

        public Deptment()
        {
            CreationTime = DateTime.Now;
        }

        public void Add(string code, string name, string parentId)
        {
            Code = code;
            Name = name;
            ParentId = parentId;
            Status = CommonStatus.Normal;
        }

        public void Edit(string code, string name)
        {
            Code = code;
            Name = name;
            LastModificationTime = DateTime.Now;
        }

        public void Enabled()
        {
            LastModificationTime = DateTime.Now;
            Status = CommonStatus.Normal;
        }

        public void Disabled()
        {
            LastModificationTime = DateTime.Now;
            Status = CommonStatus.Disabled;
        }

        public void Delete()
        {
            LastModificationTime = DateTime.Now;
            Status = CommonStatus.Deleted;
            IsDeleted = true;
            DeletionTime = DateTime.Now;
        }
    }
}