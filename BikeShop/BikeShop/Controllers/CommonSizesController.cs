using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class CommonSizesController : Controller
    {
        // GET: CommonSizes
        public ActionResult Index()
        {
            IEnumerable<CommonSizeViewModel> cs = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");
                var responseTask = client.GetAsync("commonsize");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CommonSizeViewModel>>();
                    readTask.Wait();

                    cs = readTask.Result;
                }
                else
                {
                    cs = Enumerable.Empty<CommonSizeViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(cs);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CommonSizeViewModel cs)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/commonsize");

                var postTask = client.PostAsXmlAsync<CommonSizeViewModel>("commonsize", cs);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error.");
            return View(cs);
        }

        //No need for Edit, as the only fields are primary keys, which cannot be edited

        /*public ActionResult Edit(string model, int frame)
        {
            CommonSizeViewModel bike = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/");

                var responseTask = client.GetAsync("commonsize?model=" + model.ToString() + "&frame=" + frame.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CommonSizeViewModel>();
                    readTask.Wait();

                    bike = readTask.Result;
                }
            }
            return View(bike);
        }

        [HttpPost]
        public ActionResult Edit(CommonSizeViewModel cs)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/commonsize");

                var putTask = client.PutAsXmlAsync<CommonSizeViewModel>("commonsize", cs);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(cs);
        }*/

        public ActionResult Delete(string model, int frame)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51968/api/commonsize");

                var deleteTask = client.DeleteAsync("bicycle/" + model.ToString() + "&" + frame.ToString());
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