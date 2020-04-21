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

        public IHttpActionResult GetWorkArea(string id)
        {
            WorkAreaViewModel workarea = null;

            using (var ctx = new BikeShopEntities())
            {
                workarea = ctx.WORKAREAs
                    .Where(w => w.WORKAREA1 == id)
                    .Select(w => new WorkAreaViewModel()
                    {
                        WORKAREA1 = w.WORKAREA1,
                        DESCRIPTION = w.DESCRIPTION
                    }).FirstOrDefault<WorkAreaViewModel>();
            }
            if (workarea == null)
            {
                return NotFound();
            }
            return Ok(workarea);
        }

        public IHttpActionResult PostNewWorkArea(WorkAreaViewModel w)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.WORKAREAs.Add(new WORKAREA()
                {
                    WORKAREA1 = w.WORKAREA1,
                    DESCRIPTION = w.DESCRIPTION
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(WorkAreaViewModel workArea)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingWA = ctx.WORKAREAs.Where(w => w.WORKAREA1 == workArea.WORKAREA1).FirstOrDefault<WORKAREA>();
                if (existingWA != null)
                {
                    existingWA.WORKAREA1 = workArea.WORKAREA1;
                    existingWA.DESCRIPTION = workArea.DESCRIPTION;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        public IHttpActionResult Delete(string id)
        {
           
            using (var ctx = new BikeShopEntities())
            {
                var workArea = ctx.WORKAREAs
                    .Where(w => w.WORKAREA1 == id)
                    .FirstOrDefault();

                ctx.Entry(workArea).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
