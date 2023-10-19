using System.Web;
using System.Web.Mvc;

namespace AlbumsMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //da mora najava za site formi vo aplikacijata:
            filters.Add(new AuthorizeAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
