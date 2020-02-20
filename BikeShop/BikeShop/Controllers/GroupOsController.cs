using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class GroupOsController : Controller
    {
        // GET: GroupOs
        public ActionResult Index()
        {
            IEnumerable<GroupOViewModel> go = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("groupo");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<GroupOViewModel>>();
                    readTask.Wait();

                    go = readTask.Result;
                }
                else
                {
                    go = Enumerable.Empty<GroupOViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(go);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GroupOViewModel go)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/groupo");

                var postTask = client.PostAsXmlAsync<GroupOViewModel>("groupo", go);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(go);
        }

        public ActionResult Edit(int id)
        {
            GroupOViewModel go = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("groupo?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<GroupOViewModel>();
                    readTask.Wait();

                    go = readTask.Result;
                }
            }
            return View(go);
        }

        [HttpPost]
        public ActionResult Edit(GroupOViewModel go)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/bicycle");

                var putTask = client.PutAsXmlAsync<GroupOViewModel>("groupo", go);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(go);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/groupo");

                var deleteTask = client.DeleteAsync("groupo/" + id.ToString());
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