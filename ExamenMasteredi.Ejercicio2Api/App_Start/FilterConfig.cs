using System.Web;
using System.Web.Mvc;

namespace ExamenMasteredi.Ejercicio2Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
