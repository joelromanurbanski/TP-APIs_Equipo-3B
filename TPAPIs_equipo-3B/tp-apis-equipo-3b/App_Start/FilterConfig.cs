using System.Web;
using System.Web.Mvc;

namespace tp_apis_equipo_3b
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
