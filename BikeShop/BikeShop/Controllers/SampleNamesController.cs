using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class SampleNamesController : Controller
    {
        // GET: SampleNames
        public ActionResult Index()
        {
            IEnumerable<SampleNameViewModel> s = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("samplename");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<SampleNameViewModel>>();
                    readTask.Wait();

                    s = readTask.Result;
                }
                else
                {
                    s = Enumerable.Empty<SampleNameViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(s);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SampleNameViewModel s)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/samplename");

                var postTask = client.PostAsXmlAsync<SampleNameViewModel>("samplename", s);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(s);
        }

        public ActionResult Edit(int id)
        {
            SampleNameViewModel s = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("samplename?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<SampleNameViewModel>();
                    readTask.Wait();

                    s = readTask.Result;
                }
            }
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(SampleNameViewModel s)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/samplename");

                var putTask = client.PutAsXmlAsync<SampleNameViewModel>("samplename", s);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(s);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/samplename");

                var deleteTask = client.DeleteAsync("samplename/" + id.ToString());
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