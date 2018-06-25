using Abp.Web.Mvc.Views;

namespace AssetManagement.Web.Views
{
    public abstract class AssetManagementWebViewPageBase : AssetManagementWebViewPageBase<dynamic>
    {

    }

    public abstract class AssetManagementWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected AssetManagementWebViewPageBase()
        {
            LocalizationSourceName = AssetManagementConsts.LocalizationSourceName;
        }
    }
}