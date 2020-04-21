using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class PreferencesController : Controller
    {
        // GET: Preferences
        public ActionResult Index()
        {
            IEnumerable<PreferenceViewModel> p = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("preference");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PreferenceViewModel>>();
                    readTask.Wait();

                    p = readTask.Result;
                }
                else
                {
                    p = Enumerable.Empty<PreferenceViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(p);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PreferenceViewModel p)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/preference");

                var postTask = client.PostAsXmlAsync<PreferenceViewModel>("preference", p);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(p);
        }

        public ActionResult Edit(string item)
        {
            PreferenceViewModel p = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("preference?item=" + item);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PreferenceViewModel>();
                    readTask.Wait();

                    p = readTask.Result;
                }
            }
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(PreferenceViewModel p)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/preference");

                var putTask = client.PutAsXmlAsync<PreferenceViewModel>("preference", p);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(p);
        }

        public ActionResult Delete(string item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/preference");

                var deleteTask = client.DeleteAsync("preference/" + item);
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