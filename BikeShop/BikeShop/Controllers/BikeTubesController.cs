using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class BikeTubesController : Controller
    {
        // GET: BikeTubes
        public ActionResult Index()
        {
            IEnumerable<BikeTubesViewModel> bikes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("biketube");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BikeTubesViewModel>>();
                    readTask.Wait();

                    bikes = readTask.Result;
                }
                else
                {
                    bikes = Enumerable.Empty<BikeTubesViewModel>();
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
        public ActionResult Create(BikeTubesViewModel bike)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/biketube");

                var postTask = client.PostAsXmlAsync<BikeTubesViewModel>("biketube", bike);
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

        public ActionResult Edit(int id, string tube)
        {
            BikeTubesViewModel bike = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("biketube?serial=" + id.ToString() + "&tube=" + tube.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BikeTubesViewModel>();
                    readTask.Wait();

                    bike = readTask.Result;
                }
            }
            return View(bike);
        }

        [HttpPost]
        public ActionResult Edit(BikeTubesViewModel bike)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/biketube");

                var putTask = client.PutAsXmlAsync<BikeTubesViewModel>("biketube", bike);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(bike);
        }

        public ActionResult Delete(int serial, string tube)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/biketube");

                var deleteTask = client.DeleteAsync("biketube/" + serial.ToString() + "&" + tube.ToString());
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