using Abp.AutoMapper;
using AssetManagement.Sessions.Dto;

namespace AssetManagement.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}