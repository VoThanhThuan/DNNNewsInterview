using DotNetNuke.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DNNNews.Modules.DNNNews.Api.Controller
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("DNNNews",
                "default",
                "{Controller}/{action}/{id}",
                new { id = UrlParameter.Optional },
                new[] { "DNNNews.Modules.DNNNews.Api.Controller" });
        }
    }
}
