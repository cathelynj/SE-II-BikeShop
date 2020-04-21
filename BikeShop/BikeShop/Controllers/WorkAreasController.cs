using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class WorkAreasController : Controller
    {
        // GET: WorkAreas
        public ActionResult Index()
        {
            IEnumerable<WorkAreaViewModel> workAreas = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("workarea");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<WorkAreaViewModel>>();
                    readTask.Wait();

                    workAreas = readTask.Result;
                }
                else
                {
                    workAreas = Enumerable.Empty<WorkAreaViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(workAreas);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(WorkAreaViewModel workArea)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/workarea");

                var postTask = client.PostAsXmlAsync<WorkAreaViewModel>("workarea", workArea);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(workArea);
        }

        public ActionResult Edit(string id)
        {
            WorkAreaViewModel workArea = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("workarea?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<WorkAreaViewModel>();
                    readTask.Wait();

                    workArea = readTask.Result;
                }
            }
            return View(workArea);
        }

        [HttpPost]
        public ActionResult Edit(WorkAreaViewModel workArea)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/workarea");

                var putTask = client.PutAsXmlAsync<WorkAreaViewModel>("workarea", workArea);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(workArea);
        }

        public ActionResult Delete(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/workarea");

                var deleteTask = client.DeleteAsync("workarea/" + id.ToString());
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