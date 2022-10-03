using DotNetNuke.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NewsCategories.Modules.DNNNewsCategories.Api.Controllers
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("DNNNewsCategories", 
                "default", 
                "{Controller}/{action}/{id}",
                new {id = UrlParameter.Optional},
                new[] {"NewsCategories.Modules.DNNNewsCategories.Api.Controllers"});
        }
    }
}
