using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AssetManagement.Depts.Dto;

namespace AssetManagement.Depts
{
    public class DeptAppService : AssetManagementAppServiceBase, IDeptAppService
    {
        private readonly IRepository<Deptment, string> _deptmentRepository;

        public DeptAppService(IRepository<Deptment, string> deptmentRepository)
        {
            _deptmentRepository = deptmentRepository;
        }

        public async Task CreateDept(DeptInput deptInput)
        {
            var dept = new Deptment();
            dept.Add(deptInput.Code, deptInput.Name, deptInput.ParentId);
            await _deptmentRepository.InsertAsync(dept).ConfigureAwait(false);
        }

        public async Task EditDept(DeptInput deptInput)
        {
            var dept = await _deptmentRepository.SingleAsync(c => c.Id == deptInput.Id).ConfigureAwait(false);
            dept.Edit(deptInput.Code, deptInput.Name);
            await _deptmentRepository.UpdateAsync(dept).ConfigureAwait(false);
        }

        public async Task EnableDept(DeptIdInput deptIdInput)
        {
            var dept = await _deptmentRepository.FirstOrDefaultAsync(c => c.Id == deptIdInput.Id)
                .ConfigureAwait(false);
            if (dept != null)
            {
                dept.Enabled();
            }
        }

        public async Task DisableDept(DeptIdInput deptIdInput)
        {
            var dept = await _deptmentRepository.FirstOrDefaultAsync(c => c.Id == deptIdInput.Id)
                .ConfigureAwait(false);
            if (dept != null)
            {
                dept.Disabled();
            }
        }

        public async Task RemoveDept(DeptIdInput deptIdInput)
        {
            var dept = await _deptmentRepository.FirstOrDefaultAsync(c => c.Id == deptIdInput.Id)
                .ConfigureAwait(false);
            if (dept != null)
            {
                await _deptmentRepository.DeleteAsync(dept).ConfigureAwait(false);
            }
        }

        [HttpGet]
        public async Task<ListResultDto<DeptDto>> GetDepts()
        {
            var depts = await _deptmentRepository.GetAllListAsync().ConfigureAwait(false);

            return await Task.FromResult(new ListResultDto<DeptDto>(
                ObjectMapper.Map<List<DeptDto>>(depts)
            )).ConfigureAwait(false);
        }
    }
}