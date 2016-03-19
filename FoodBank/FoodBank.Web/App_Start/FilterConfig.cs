using System.Web;
using System.Web.Mvc;
using FoodBank.Web.Helpers.Attributes;

namespace FoodBank.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new TtcHandleErrorAttribute());
            // filters.Add(new RequireHttpsAttribute());

        }
    }
}
