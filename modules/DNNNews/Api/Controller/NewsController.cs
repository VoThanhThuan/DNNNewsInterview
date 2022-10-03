using DNNNews.Modules.DNNNews.Components;
using DNNNews.Modules.DNNNews.Models;
using DotNetNuke.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DNNNews.Modules.DNNNews.Api.Controller
{
    public class NewsController: DnnApiController
    {

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage Hello()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello There!");
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetListNews()
        {
            return Request.CreateResponse(HttpStatusCode.OK, ItemManager.Instance.GetItems());
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetAll(int take = 20, int skip = 0, int category = -1)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ItemManager.Instance.GetAll(take, skip, category));
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetNews(int itemId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ItemManager.Instance.GetItem(itemId));
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage TotalNews(int category = -1, string keywords = "")
        {
            return Request.CreateResponse(HttpStatusCode.OK, ItemManager.Instance.TotalNews(category, keywords));
        }

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage Search(string keywords, int take = 20, int skip = 0)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ItemManager.Instance.Search(keywords));
        }
        [HttpPost]
        public HttpResponseMessage AddNews(Item item)
        {
            ItemManager.Instance.CreateItem(item);
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        [HttpPut]
        public HttpResponseMessage UpdateNews(Item item)
        {
            ItemManager.Instance.UpdateItem(item);
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteNews(int itemId)
        {
            ItemManager.Instance.DeleteItem(itemId);
            return Request.CreateResponse(HttpStatusCode.OK, itemId);
        }
    }
}
