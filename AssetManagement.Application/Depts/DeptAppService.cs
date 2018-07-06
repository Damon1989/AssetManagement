using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
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

        private async Task CheckCreateDept(string code, string parentId)
        {
            var dept = new Deptment();
            if (parentId != Guid.Empty.ToString().Replace("-", ""))
            {
                dept = await _deptmentRepository.FirstOrDefaultAsync(d => d.Id == parentId).ConfigureAwait(false);
                if (dept == null)
                {
                    throw new UserFriendlyException($"父级部门不存在");
                }
            }
            dept = await _deptmentRepository.FirstOrDefaultAsync(d => d.Code == code)
               .ConfigureAwait(false);
            if (dept != null)
            {
                throw new UserFriendlyException($"部门编号{code}必须唯一");
            }
        }

        public async Task CreateDept(DeptInput deptInput)
        {
            var dept = new Deptment();
            await CheckCreateDept(deptInput.Code, deptInput.ParentId).ConfigureAwait(false);
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

        public async Task<List<DeptDto>> GetDepts(string parentId)
        {
            var depts = await _deptmentRepository.GetAllListAsync(c => c.ParentId == parentId).ConfigureAwait(false);

            //return await Task.FromResult(new ListResultDto<DeptDto>(
            //    ObjectMapper.Map<List<DeptDto>>(depts)
            //)).ConfigureAwait(false);

            var result = new List<DeptDto>();
            depts.ForEach(dept =>
            {
                result.Add(new DeptDto { Id = dept.Id, Text = dept.Name });
            });

            return result;
        }
    }
}