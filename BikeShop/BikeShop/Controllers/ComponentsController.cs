using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class ComponentsController : Controller
    {
        // GET: Components
        public ActionResult Index()
        {
            IEnumerable<ComponentViewModel> c = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("component");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ComponentViewModel>>();
                    readTask.Wait();

                    c = readTask.Result;
                }
                else
                {
                    c = Enumerable.Empty<ComponentViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(c);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ComponentViewModel c)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/component");

                var postTask = client.PostAsXmlAsync<ComponentViewModel>("bicycle", c);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(c);
        }

        public ActionResult Edit(int id)
        {
            ComponentViewModel c = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("component?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ComponentViewModel>();
                    readTask.Wait();

                    c = readTask.Result;
                }
            }
            return View(c);
        }

        [HttpPost]
        public ActionResult Edit(ComponentViewModel c)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/component");

                var putTask = client.PutAsXmlAsync<ComponentViewModel>("component", c);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(c);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/component");

                var deleteTask = client.DeleteAsync("component/" + id.ToString());
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