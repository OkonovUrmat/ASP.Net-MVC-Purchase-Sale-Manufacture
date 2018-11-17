using System.Web;
using System.Web.Mvc;

namespace Module_2_Zakupka_Prodaja_Proizvodstvo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
