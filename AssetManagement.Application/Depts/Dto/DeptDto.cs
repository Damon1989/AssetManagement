using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace AssetManagement.Depts.Dto
{
    [AutoMapFrom(typeof(Deptment))]
    public class DeptDto : EntityDto<string>
    {
        //public string Parent { get; set; }

        //public string Code { get; set; }
        //public string Name { get; set; }
        //public string IsActive { get; set; }
        public string Text { get; set; }

        public bool Children => true;
        public string Icon => "fa fa-folder icon-state-warning icon-lg";
    }
}