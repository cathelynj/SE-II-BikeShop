using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class PaintsController : Controller
    {
        // GET: Paints
        public ActionResult Index()
        {
            IEnumerable<PaintViewModel> p = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("paint");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PaintViewModel>>();
                    readTask.Wait();

                    p = readTask.Result;
                }
                else
                {
                    p = Enumerable.Empty<PaintViewModel>();
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
        public ActionResult Create(PaintViewModel p)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/paint");

                var postTask = client.PostAsXmlAsync<PaintViewModel>("paint", p);
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

        public ActionResult Edit(int id)
        {
            PaintViewModel p = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("paint?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PaintViewModel>();
                    readTask.Wait();

                    p = readTask.Result;
                }
            }
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(PaintViewModel p)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/bicycle");

                var putTask = client.PutAsXmlAsync<PaintViewModel>("paint", p);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(p);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/paint");

                var deleteTask = client.DeleteAsync("paint/" + id.ToString());
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