using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class ManufactorerTransactionsController : Controller
    {
        
        public ActionResult Index()
        {
            IEnumerable<ManufactorerTransactionViewModel> manufactorerTransactions = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("manufactorertransaction");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ManufactorerTransactionViewModel>>();
                    readTask.Wait();

                    manufactorerTransactions = readTask.Result;
                }
                else
                {
                    manufactorerTransactions = Enumerable.Empty<ManufactorerTransactionViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(manufactorerTransactions);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ManufactorerTransactionViewModel mt)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/manufactorertransaction");

                var postTask = client.PostAsXmlAsync<ManufactorerTransactionViewModel>("manufactorertransaction", mt);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(mt);
        }

        public ActionResult Edit(int id, System.DateTime date, int reference)
        {
            ManufactorerTransactionViewModel manufactorerTransaction = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("manufactorertransaction?id=" + id.ToString() + "&date=" + date.ToString() + "&reference=" + reference.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ManufactorerTransactionViewModel>();
                    readTask.Wait();

                    manufactorerTransaction = readTask.Result;
                }
            }
            return View(manufactorerTransaction);
        }

        [HttpPost]
        public ActionResult Edit(ManufactorerTransactionViewModel mt)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/manufactorertransaction");

                var putTask = client.PutAsXmlAsync<ManufactorerTransactionViewModel>("manufactorertransaction", mt);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(mt);
        }

        public ActionResult Delete(int id, System.DateTime date, int reference)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/manufactorertransaction");

                var deleteTask = client.DeleteAsync("manufactorertransaction/" + id.ToString() + "&" + date.ToString() + "&" + reference.ToString());
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