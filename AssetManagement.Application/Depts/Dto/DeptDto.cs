using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace AssetManagement.Depts.Dto
{
    [AutoMapFrom(typeof(Deptment))]
    public class DeptDto : EntityDto<string>
    {
        public string ParentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}