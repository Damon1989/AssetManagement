using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AssetManagement.Depts.Dto;

namespace AssetManagement.Depts
{
    public interface IDeptAppService : IApplicationService
    {
        Task CreateDept(DeptInput deptInput);

        Task EditDept(DeptInput deptInput);

        Task EnableDept(DeptIdInput deptIdInput);

        Task DisableDept(DeptIdInput deptIdInput);

        Task RemoveDept(DeptIdInput deptIdInput);

        Task<ListResultDto<DeptDto>> GetDepts();
    }
}