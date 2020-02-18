using BikeShop.Models;
using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BikeShop.Controllers.api
{
    public class WorkAreaController : ApiController
    {
        public IHttpActionResult GetAllWorkAreas()
        {
            IList<WorkAreaViewModel> workareas = null;
            using (var ctx = new BikeShopEntities())
            {
                workareas = ctx.WORKAREAs.Select(w => new WorkAreaViewModel()
                {
                    WORKAREA1 = w.WORKAREA1,
                    DESCRIPTION = w.DESCRIPTION
                }).ToList<WorkAreaViewModel>();
            }
            if (workareas.Count == 0)
            {
                return NotFound();
            }

            return Ok(workareas);
        }
    }
}
