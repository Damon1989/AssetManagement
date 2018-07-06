using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Web.Models;
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

        [HttpGet]
        [DontWrapResult]
        Task<List<DeptDto>> GetDepts(string parentId);
    }
}