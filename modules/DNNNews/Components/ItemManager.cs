/*
' Copyright (c) 2022 VoThuan
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using DNNNews.Modules.DNNNews.Models;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using System.Collections.Generic;
using System.Data;

namespace DNNNews.Modules.DNNNews.Components
{
    internal interface IItemManager
    {
        void CreateItem(Item t);
        void DeleteItem(int itemId);
        void DeleteItem(Item t);
        IEnumerable<Item> GetItems();
        IEnumerable<Item> GetAll(int take = 20, int skip = 0, int category = -1);
        int TotalNews(int category = -1, string keywords = "");
        IEnumerable<Item> Search(string keywords, int take = 20, int skip = 0);
        Item GetItem(int itemId);
        void UpdateItem(Item t);
    }

    internal class ItemManager : ServiceLocator<IItemManager, ItemManager>, IItemManager
    {
        public void CreateItem(Item t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                rep.Insert(t);
            }
        }

        public void DeleteItem(int itemId)
        {
            var t = GetItem(itemId);
            DeleteItem(t);
        }

        public void DeleteItem(Item t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                rep.Delete(t);
            }
        }

        public IEnumerable<Item> GetItems()
        {
            IEnumerable<Item> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                t = rep.Get();
            }
            return t;
        }

        public IEnumerable<Item> GetAll(int take = 20, int skip = 0, int category = -1)
        {
            IEnumerable<Item> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                if (category < 0)
                {
                    t = ctx.ExecuteQuery<Item>(CommandType.Text, "SELECT * FROM [dbo].DNNNews ORDER BY [CreatedOnDate] DESC OFFSET @0 ROWS FETCH NEXT @1 ROWS ONLY;", skip, take);
                }
                else
                {
                    t = ctx.ExecuteQuery<Item>(CommandType.Text, "SELECT * FROM [dbo].DNNNews WHERE [NewsCategoriesId] = @0 ORDER BY [CreatedOnDate] DESC OFFSET @1 ROWS FETCH NEXT @2 ROWS ONLY;", category, skip, take);
                }
            }
            return t;
        }

        public int TotalNews(int category = -1, string keywords = "")
        {
            int t;
            using (IDataContext ctx = DataContext.Instance())
            {
                if (string.IsNullOrEmpty(keywords))
                {
                    if (category < 0)
                    {
                        t = ctx.ExecuteSingleOrDefault<int>(CommandType.Text, "Select Count(*) from [dbo].DNNNews;");
                    }
                    else
                    {
                        t = ctx.ExecuteSingleOrDefault<int>(CommandType.Text, "SELECT Count(*) from [dbo].DNNNews WHERE [NewsCategoriesId] = @0;", category);
                    }
                }
                else
                {
                    t = ctx.ExecuteSingleOrDefault<int>(CommandType.Text, "SELECT Count(*) FROM [dbo].DNNNews WHERE [ItemName] LIKE @0;", $"%{keywords}%");
                }

            }
            return t;
        }
        public IEnumerable<Item> Search(string keywords, int take = 20, int skip = 0)
        {
            IEnumerable<Item> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                t = ctx.ExecuteQuery<Item>(CommandType.Text, "SELECT * FROM [dbo].DNNNews WHERE [ItemName] LIKE @0 ORDER BY [CreatedOnDate] DESC OFFSET @1 ROWS FETCH NEXT @2 ROWS ONLY;", $"%{keywords}%", skip, take);
            }
            return t;
        }


        public Item GetItem(int itemId)
        {
            Item t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                t = rep.GetById(itemId);
            }
            return t;
        }

        public void UpdateItem(Item t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                rep.Update(t);
            }
        }

        protected override System.Func<IItemManager> GetFactory()
        {
            return () => new ItemManager();
        }
    }
}
