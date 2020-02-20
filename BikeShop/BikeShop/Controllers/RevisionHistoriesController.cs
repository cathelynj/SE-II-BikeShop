using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class RevisionHistoriesController : Controller
    {
        // GET: RevisionHistories
        public ActionResult Index()
        {
            IEnumerable<RevisionHistoryViewModel> r = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("revisionhistory");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<RevisionHistoryViewModel>>();
                    readTask.Wait();

                    r = readTask.Result;
                }
                else
                {
                    r = Enumerable.Empty<RevisionHistoryViewModel>();
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
        public ActionResult Create(RevisionHistoryViewModel r)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/revisionhistory");

                var postTask = client.PostAsXmlAsync<RevisionHistoryViewModel>("revisionhistory", r);
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
            RevisionHistoryViewModel r = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("revisionhistory?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RevisionHistoryViewModel>();
                    readTask.Wait();

                    r = readTask.Result;
                }
            }
            return View(r);
        }

        [HttpPost]
        public ActionResult Edit(RevisionHistoryViewModel r)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/revisionhistory");

                var putTask = client.PutAsXmlAsync<RevisionHistoryViewModel>("revisionhistory", r);
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
                client.BaseAddress = new Uri("http://localhost:51968/api/revisionhistory");

                var deleteTask = client.DeleteAsync("revisionhistory/" + id.ToString());
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