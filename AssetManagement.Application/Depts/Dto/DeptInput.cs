using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Depts.Dto
{
    public class DeptInput
    {
        public string Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ParentId { get; set; }
    }
}