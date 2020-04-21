using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class PurchaseOrdersController : Controller
    {
        // GET: PurchaseOrders
        public ActionResult Index()
        {
            IEnumerable<PurchaseOrderViewModel> po = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("purchaseorder");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PurchaseOrderViewModel>>();
                    readTask.Wait();

                    po = readTask.Result;
                }
                else
                {
                    po = Enumerable.Empty<PurchaseOrderViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(po);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PurchaseOrderViewModel po)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/purchaseorder");

                var postTask = client.PostAsXmlAsync<PurchaseOrderViewModel>("purchaseorder", po);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(po);
        }

        public ActionResult Edit(int id)
        {
            PurchaseOrderViewModel po = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("purchaseorder?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PurchaseOrderViewModel>();
                    readTask.Wait();

                    po = readTask.Result;
                }
            }
            return View(po);
        }

        [HttpPost]
        public ActionResult Edit(PurchaseOrderViewModel po)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/purchaseorder");

                var putTask = client.PutAsXmlAsync<PurchaseOrderViewModel>("purchaseorder", po);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(po);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/purchaseorder");

                var deleteTask = client.DeleteAsync("purchaseorder/" + id.ToString());
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