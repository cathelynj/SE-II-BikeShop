using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class BicyclesController : Controller
    {
        // GET: Bicycles
        public ActionResult Index()
        {
            IEnumerable<BicycleViewModel> bikes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("bicycle");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BicycleViewModel>>();
                    readTask.Wait();

                    bikes = readTask.Result;
                }
                else
                {
                    bikes = Enumerable.Empty<BicycleViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(bikes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BicycleViewModel bike)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/bicycle");

                var postTask = client.PostAsXmlAsync<BicycleViewModel>("bicycle", bike);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(bike);
        }

        public ActionResult Edit(int id)
        {
            BicycleViewModel bike = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("bicycle?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BicycleViewModel>();
                    readTask.Wait();

                    bike = readTask.Result;
                }
            }
            return View(bike);
        }

        [HttpPost]
        public ActionResult Edit(BicycleViewModel bike)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/bicycle");

                var putTask = client.PutAsXmlAsync<BicycleViewModel>("bicycle", bike);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(bike);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/bicycle");

                var deleteTask = client.DeleteAsync("bicycle/" + id.ToString());
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