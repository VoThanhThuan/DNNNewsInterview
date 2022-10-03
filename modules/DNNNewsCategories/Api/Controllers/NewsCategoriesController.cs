using DotNetNuke.Common.Utilities;
using DotNetNuke.Web.Api;
using NewsCategories.Modules.DNNNewsCategories.Components;
using NewsCategories.Modules.DNNNewsCategories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;
    
namespace NewsCategories.Modules.DNNNewsCategories.Api.Controllers
{
    public class NewsCategoriesController : DnnApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage Hello()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello There!");
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetCategories()
        {           
            return Request.CreateResponse(HttpStatusCode.OK, ItemManager.Instance.GetItems());
        }
        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage Search(string keywords)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ItemManager.Instance.Search(keywords));
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetCategory(int itemId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ItemManager.Instance.GetItem(itemId));
        }

        [HttpPost]
        public HttpResponseMessage AddCategory(Item item)
        {
            ItemManager.Instance.CreateItem(item);
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        [HttpPut]
        public HttpResponseMessage UpdateCategory(Item item)
        {
            ItemManager.Instance.UpdateItem(item);
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteCategory(int itemId)
        {
            ItemManager.Instance.DeleteItem(itemId);
            return Request.CreateResponse(HttpStatusCode.OK, itemId);
        }
    }
}
