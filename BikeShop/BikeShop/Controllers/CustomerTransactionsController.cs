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
    }
}