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
    public class StateTaxRateController : ApiController
    {
        public IHttpActionResult GetAllStateTaxRates()
        {
            IList<StateTaxRateViewModel> taxrate = null;
            using (var ctx = new BikeShopEntities())
            {
                taxrate = ctx.STATETAXRATEs.Select(s => new StateTaxRateViewModel()
                {
                   STATE = s.STATE,
                   TAXRATE = s.TAXRATE
                }).ToList<StateTaxRateViewModel>();
            }
            if (taxrate.Count == 0)
            {
                return NotFound();
            }

            return Ok(taxrate);
        }

        public IHttpActionResult GetStateTaxRate(string id)
        {
            StateTaxRateViewModel bikeParts = null;

            using (var ctx = new BikeShopEntities())
            {
                bikeParts = ctx.STATETAXRATEs
                    .Where(s => s.STATE == id)
                    .Select(s => new StateTaxRateViewModel()
                    {
                        STATE = s.STATE,
                        TAXRATE = s.TAXRATE
                    }).FirstOrDefault<StateTaxRateViewModel>();
            }
            if (bikeParts == null)
            {
                return NotFound();
            }
            return Ok(bikeParts);
        }

        public IHttpActionResult PostNewStateTaxRate(StateTaxRateViewModel s)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.STATETAXRATEs.Add(new STATETAXRATE()
                {
                    STATE = s.STATE,
                    TAXRATE = s.TAXRATE
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(StateTaxRateViewModel s)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.STATETAXRATEs.Where(w => w.STATE == s.STATE).FirstOrDefault<STATETAXRATE>();
                if (existingBP != null)
                {
                    existingBP.STATE = s.STATE;
                    existingBP.TAXRATE = s.TAXRATE;

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
                var bp = ctx.STATETAXRATEs
                    .Where(w => w.STATE == id)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
