using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class TubeMaterialsController : Controller
    {
        // GET: TubeMaterials
        public ActionResult Index()
        {
            IEnumerable<TubeMaterialViewModel> bikes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("tubematerial");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<TubeMaterialViewModel>>();
                    readTask.Wait();

                    bikes = readTask.Result;
                }
                else
                {
                    bikes = Enumerable.Empty<TubeMaterialViewModel>();
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
        public ActionResult Create(TubeMaterialViewModel bike)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/tubematerial");

                var postTask = client.PostAsXmlAsync<TubeMaterialViewModel>("tubematerial", bike);
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
            TubeMaterialViewModel bike = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("tubematerial?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<TubeMaterialViewModel>();
                    readTask.Wait();

                    bike = readTask.Result;
                }
            }
            return View(bike);
        }

        [HttpPost]
        public ActionResult Edit(TubeMaterialViewModel bike)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/tubematerial");

                var putTask = client.PutAsXmlAsync<TubeMaterialViewModel>("tubematerial", bike);
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
                client.BaseAddress = new Uri("http://localhost:51968/api/tubematerial");

                var deleteTask = client.DeleteAsync("tubematerial/" + id.ToString());
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