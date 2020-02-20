using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class PurchaseItemsController : Controller
    {
        // GET: PurchaseItems
        public ActionResult Index()
        {
            IEnumerable<PurchaseItemViewModel> pi = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("purchaseitem");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PurchaseItemViewModel>>();
                    readTask.Wait();

                    pi = readTask.Result;
                }
                else
                {
                    pi = Enumerable.Empty<PurchaseItemViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(pi);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PurchaseItemViewModel pi)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/purchaseitem");

                var postTask = client.PostAsXmlAsync<PurchaseItemViewModel>("purchaseitem", pi);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(pi);
        }

        public ActionResult Edit(int purchaseID, int componentID)
        {
            PurchaseItemViewModel pi = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("purchaseitem?purchaseID=" + purchaseID.ToString() + "&componentID=" + componentID.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PurchaseItemViewModel>();
                    readTask.Wait();

                    pi = readTask.Result;
                }
            }
            return View(pi);
        }

        [HttpPost]
        public ActionResult Edit(PurchaseItemViewModel pi)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/purchaseitem");

                var putTask = client.PutAsXmlAsync<PurchaseItemViewModel>("purchaseitem", pi);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(pi);
        }

        public ActionResult Delete(int purchaseID, int componentID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/purchaseitem");

                var deleteTask = client.DeleteAsync("purchaseitem/" + purchaseID.ToString() + "&" + componentID);
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