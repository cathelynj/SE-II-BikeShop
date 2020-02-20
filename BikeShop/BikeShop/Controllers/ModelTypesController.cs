using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class ModelTypesController : Controller
    {
        // GET: ModelTypes
        public ActionResult Index()
        {
            IEnumerable<ModelTypeViewModel> mt = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("modeltype");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ModelTypeViewModel>>();
                    readTask.Wait();

                    mt = readTask.Result;
                }
                else
                {
                    mt = Enumerable.Empty<ModelTypeViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(mt);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ModelTypeViewModel mt)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/modeltype");

                var postTask = client.PostAsXmlAsync<ModelTypeViewModel>("modeltype", mt);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(mt);
        }

        public ActionResult Edit(string type)
        {
            ModelTypeViewModel mt = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("modeltype?type=" + type.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ModelTypeViewModel>();
                    readTask.Wait();

                    mt = readTask.Result;
                }
            }
            return View(mt);
        }

        [HttpPost]
        public ActionResult Edit(ModelTypeViewModel mt)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/modeltype");

                var putTask = client.PutAsXmlAsync<ModelTypeViewModel>("modeltyp", mt);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(mt);
        }

        public ActionResult Delete(string type)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/modeltype");

                var deleteTask = client.DeleteAsync("modeltype/" + type.ToString());
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