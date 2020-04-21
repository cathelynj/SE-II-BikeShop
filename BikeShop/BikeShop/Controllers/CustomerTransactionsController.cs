using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class CustomerTransactionsController : Controller
    {
        // GET: CustomerTransactions
        public ActionResult Index()
        {
            IEnumerable<CustomerTransactionViewModel> customertransactions = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("customertransaction");
                responseTask.Wait();

                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CustomerTransactionViewModel>>();
                    readTask.Wait();
                    customertransactions = readTask.Result;
                }
                else
                {
                    customertransactions = Enumerable.Empty<CustomerTransactionViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(customertransactions);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerTransactionViewModel ct)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/customertransaction");

                var postTask = client.PostAsXmlAsync<CustomerTransactionViewModel>("customertransaction", ct);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(ct);
        }

        public ActionResult Edit(int id, System.DateTime date)
        {
            CustomerTransactionViewModel ct = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("customertransaction?id=" + id.ToString() + "&date=" + date.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CustomerTransactionViewModel>();
                    readTask.Wait();

                    ct = readTask.Result;
                }
            }
            return View(ct);
        }

        [HttpPost]
        public ActionResult Edit(CustomerTransactionViewModel ct)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/customertransaction");

                var putTask = client.PutAsXmlAsync<CustomerTransactionViewModel>("customertransaction", ct);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ct);
        }

        public ActionResult Delete(int id, System.DateTime date)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/customertransaction");

                var deleteTask = client.DeleteAsync("customertransaction/" + id.ToString() + "&" + date.ToString());
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