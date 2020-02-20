using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class ModelSizesController : Controller
    {
        // GET: ModelSizes
        public ActionResult Index()
        {
            IEnumerable<ModelSizeViewModel> ms = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("modelsize");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ModelSizeViewModel>>();
                    readTask.Wait();

                    ms = readTask.Result;
                }
                else
                {
                    ms = Enumerable.Empty<ModelSizeViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(ms);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ModelSizeViewModel ms)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/modelsize");

                var postTask = client.PostAsXmlAsync<ModelSizeViewModel>("modelsize", ms);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(ms);
        }

        public ActionResult Edit(string type, int size)
        {
            ModelSizeViewModel ms = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("modelsize?type=" + type.ToString() + "&size=" + size.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ModelSizeViewModel>();
                    readTask.Wait();

                    ms = readTask.Result;
                }
            }
            return View(ms);
        }

        [HttpPost]
        public ActionResult Edit(ModelSizeViewModel ms)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/modelsize");

                var putTask = client.PutAsXmlAsync<ModelSizeViewModel>("modelsize", ms);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ms);
        }

        public ActionResult Delete(string type, int size)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/modelsize");

                var deleteTask = client.DeleteAsync("modelsize/" + type.ToString() + "&" + size.ToString());
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