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

using DotNetNuke.Data;
using DotNetNuke.Framework;
using NewsCategories.Modules.DNNNewsCategories.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NewsCategories.Modules.DNNNewsCategories.Components
{
    internal interface IItemManager
    {
        void CreateItem(Item t);
        void DeleteItem(int itemId);
        void DeleteItem(Item t);
        IEnumerable<Item> GetItems();
        IEnumerable<Item> GetAll(int take = 20, int skip = 0);
        IEnumerable<Item> Search(string keywords, int take = 20, int skip = 0);
        int TotalNews(string keywords = "");
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

        public IEnumerable<Item> GetAll(int take = 20, int skip = 0)
        {
            IEnumerable<Item> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                t = ctx.ExecuteQuery<Item>(CommandType.Text, "SELECT * FROM [dbo].DNNNewsCategories ORDER BY [CreatedOnDate] DESC OFFSET @0 ROWS FETCH NEXT @1 ROWS ONLY;", skip, take);
            }
            return t;
        }

        public IEnumerable<Item> Search(string keywords, int take = 20, int skip = 0)
        {
            IEnumerable<Item> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                t = ctx.ExecuteQuery<Item>(CommandType.Text, "SELECT * FROM [dbo].DNNNewsCategories WHERE [ItemName] LIKE @0 ORDER BY [CreatedOnDate] DESC OFFSET @1 ROWS FETCH NEXT @2 ROWS ONLY;", $"%{keywords}%", skip, take);
            }
            return t;
        }

        public int TotalNews(string keywords = "")
        {
            int t;
            using (IDataContext ctx = DataContext.Instance())
            {
                if (string.IsNullOrEmpty(keywords))
                {
                    t = ctx.ExecuteSingleOrDefault<int>(CommandType.Text, "Select Count(*) from [dbo].DNNNewsCategories;");
                }
                else
                {
                    t = ctx.ExecuteSingleOrDefault<int>(CommandType.Text, "SELECT Count(*) FROM [dbo].DNNNewsCategories WHERE [ItemName] LIKE @0;", $"%{keywords}%");
                }

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
