using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class CitiesController : Controller
    {
        // GET: Cities
        public ActionResult Index()
        {
            IEnumerable<CityViewModel> cities = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("city");
                responseTask.Wait();

                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CityViewModel>>();
                    readTask.Wait();

                    cities = readTask.Result;
                }
                else
                {
                    cities = Enumerable.Empty<CityViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(cities);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CityViewModel city)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/city");

                var postTask = client.PostAsXmlAsync<CityViewModel>("city", city);
                postTask.Wait();

                var result = postTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(city);
        }
    }
}