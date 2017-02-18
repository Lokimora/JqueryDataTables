using DataTableTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DataTableTests.Controllers
{
    public class DataTableController : Controller
    {
        private readonly List<String> Colors = new List<string>
       {
           "Blue", "Red", "Green"
       };

     
        // GET: DataTable
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetStores()
        {
            List<Store> stores = new List<Store>();

            for(int i = 0; i < 100; i++)
            {
                Store store = new Store()
                {
                    Id = i,
                    Name = RandomString(8),
                    Address = RandomString(15)
                };

                stores.Add(store);
            }

            return new JsonResult()
            {
                Data = stores,
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8
            };


        }


        [HttpPost]
        public JsonResult GetModels(int storeId)
        {
            List<Model> models = new List<Model>();

            for(int i = 0; i < 50; i++)
            {
                Random r = new Random();

                Model m = new Model()
                {
                    Color = Colors.ElementAt(r.Next(3)),
                    Name = RandomString(4),
                    ShopId = storeId

                };

                models.Add(m);
            }


            return new JsonResult()
            {
                Data = models,
                ContentType = "Application/json",
                ContentEncoding = Encoding.UTF8
            };
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}