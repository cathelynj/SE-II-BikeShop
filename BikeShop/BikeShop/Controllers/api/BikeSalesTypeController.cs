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
    public class BikeSalesTypeController : ApiController
    {
        public IHttpActionResult GetAllBikeSalesType()
        {
            IList<BikeSalesType> bst = null;
            using (var ctx = new SE2MetricEntities())
            {
                bst = ctx.SalesTypes.Select(t => new BikeSalesType()
                {
                    Id = t.Id,
                    modelType = t.ModelType
                }).ToList<BikeSalesType>();
            }
            if (bst.Count == 0)
            {
                return NotFound();
            }

            return Ok(bst);
        }

        public IHttpActionResult PostTransaction(BikeSalesType bst)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new SE2MetricEntities())
            {
                ctx.SalesTypes.Add(new SalesType()
                {
                    Id = bst.Id,
                    ModelType = bst.modelType
                });

                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
