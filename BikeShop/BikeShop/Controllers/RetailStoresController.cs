using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class RetailStoresController : Controller
    {
        // GET: RetailStores
        public ActionResult Index()
        {
            IEnumerable<RetailStoreViewModel> r = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("retailstore");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<RetailStoreViewModel>>();
                    readTask.Wait();

                    r = readTask.Result;
                }
                else
                {
                    r = Enumerable.Empty<RetailStoreViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(r);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RetailStoreViewModel r)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/retailstore");

                var postTask = client.PostAsXmlAsync<RetailStoreViewModel>("retailstore", r);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(r);
        }

        public ActionResult Edit(int id)
        {
            RetailStoreViewModel r = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("retailstore?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RetailStoreViewModel>();
                    readTask.Wait();

                    r = readTask.Result;
                }
            }
            return View(r);
        }

        [HttpPost]
        public ActionResult Edit(RetailStoreViewModel r)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/retailstore");

                var putTask = client.PutAsXmlAsync<RetailStoreViewModel>("retailstore", r);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(r);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/retailstore");

                var deleteTask = client.DeleteAsync("retailstore/" + id.ToString());
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