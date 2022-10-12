using System.Web;
using System.Web.Mvc;

namespace Controldeaplicaciones_TODOLIST
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
