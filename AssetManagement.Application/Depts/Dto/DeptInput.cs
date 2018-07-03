using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Depts.Dto
{
    public class DeptInput
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string ParentId { get; set; }
    }
}