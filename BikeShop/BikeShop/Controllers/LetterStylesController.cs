using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class LetterStylesController : Controller
    {
        // GET: LetterStyles
        public ActionResult Index()
        {
            IEnumerable<LetterStyleViewModel> style = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("letterstyle");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<LetterStyleViewModel>>();
                    readTask.Wait();

                    style = readTask.Result;
                }
                else
                {
                    style = Enumerable.Empty<LetterStyleViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(style);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LetterStyleViewModel letter)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/letterstyle");

                var postTask = client.PostAsXmlAsync<LetterStyleViewModel>("letterstyle", letter);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(letter);
        }

        public ActionResult Edit(string id)
        {
            LetterStyleViewModel letter = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("letterstyle?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<LetterStyleViewModel>();
                    readTask.Wait();

                    letter = readTask.Result;
                }
            }
            return View(letter);
        }

        [HttpPost]
        public ActionResult Edit(LetterStyleViewModel letter)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/letterstyle");

                var putTask = client.PutAsXmlAsync<LetterStyleViewModel>("letterstyle", letter);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(letter);
        }

        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/letterstyle");

                var deleteTask = client.DeleteAsync("letterstyle/" + id.ToString());
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