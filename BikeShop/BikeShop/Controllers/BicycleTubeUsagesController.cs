using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class BicycleTubeUsagesController : Controller
    {
        // GET: BicycleTubeUsages
        public ActionResult Index()
        {
            IEnumerable<BicycleTubeUsageViewModel> btu = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("bicycletubeusage");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BicycleTubeUsageViewModel>>();
                    readTask.Wait();

                    btu = readTask.Result;
                }
                else
                {
                    btu = Enumerable.Empty<BicycleTubeUsageViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(btu);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BicycleTubeUsageViewModel btu)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/bicycletubeusage");

                var postTask = client.PostAsXmlAsync<BicycleTubeUsageViewModel>("bicycletubeusage", btu);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(btu);
        }

        public ActionResult Edit(int serial, int tube)
        {
            BicycleTubeUsageViewModel btu = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("bicycletubeusage?serial=" + serial.ToString() + "&tube=" + tube.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BicycleTubeUsageViewModel>();
                    readTask.Wait();

                    btu = readTask.Result;
                }
            }
            return View(btu);
        }

        [HttpPost]
        public ActionResult Edit(BicycleTubeUsageViewModel btu)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/bicycletubeusage");

                var putTask = client.PutAsXmlAsync<BicycleTubeUsageViewModel>("bicycletubeusage", btu);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(btu);
        }

        public ActionResult Delete(int serial, int tube)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/bicycletubeusage");

                var deleteTask = client.DeleteAsync("bicycletubeusage/" + serial.ToString() + "&" + tube.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}