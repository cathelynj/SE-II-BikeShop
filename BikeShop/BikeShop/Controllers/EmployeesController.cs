using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<EmployeeViewModel> employees = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("employee");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<EmployeeViewModel>>();
                    readTask.Wait();
                    employees = readTask.Result;
                }
                else
                {
                    employees = Enumerable.Empty<EmployeeViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(employees);
        }
    }
}