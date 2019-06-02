using System.Web;
using System.Web.Mvc;

namespace Testarea_Lab5_Ganusceac_Vlad
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
