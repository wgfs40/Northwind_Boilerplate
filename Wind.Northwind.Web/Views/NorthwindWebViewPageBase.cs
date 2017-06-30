using Abp.Web.Mvc.Views;

namespace Wind.Northwind.Web.Views
{
    public abstract class NorthwindWebViewPageBase : NorthwindWebViewPageBase<dynamic>
    {

    }

    public abstract class NorthwindWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected NorthwindWebViewPageBase()
        {
            LocalizationSourceName = NorthwindConsts.LocalizationSourceName;
        }
    }
}