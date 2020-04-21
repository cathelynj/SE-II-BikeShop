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
    public class TempDateMadeController : ApiController
    {
        public IHttpActionResult GetAllTempDateMade()
        {
            IList<TempDateMadeViewModel> datemade = null;
            using (var ctx = new BikeShopEntities())
            {
                datemade = ctx.TEMPDATEMADEs.Select(t => new TempDateMadeViewModel()
                {
                    DATEVALUE = t.DATEVALUE,
                    MADECOUNT = t.MADECOUNT
                }).ToList<TempDateMadeViewModel>();
            }
            if (datemade.Count == 0)
            {
                return NotFound();
            }

            return Ok(datemade);
        }

        public IHttpActionResult GetTempDateMade(System.DateTime id)
        {
            TempDateMadeViewModel tdm = null;

            using (var ctx = new BikeShopEntities())
            {
                tdm = ctx.TEMPDATEMADEs
                    .Where(t => t.DATEVALUE == id)
                    .Select(t => new TempDateMadeViewModel()
                    {
                        DATEVALUE = t.DATEVALUE,
                        MADECOUNT = t.MADECOUNT
                    }).FirstOrDefault<TempDateMadeViewModel>();
            }
            if (tdm == null)
            {
                return NotFound();
            }
            return Ok(tdm);
        }

        public IHttpActionResult PostNewTempDateMade(TempDateMadeViewModel t)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.TEMPDATEMADEs.Add(new TEMPDATEMADE()
                {
                    DATEVALUE = t.DATEVALUE,
                    MADECOUNT = t.MADECOUNT
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(TempDateMadeViewModel t)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.TEMPDATEMADEs.Where(w => w.DATEVALUE == t.DATEVALUE).FirstOrDefault<TEMPDATEMADE>();
                if (existingBP != null)
                {
                    existingBP.DATEVALUE = t.DATEVALUE;
                    existingBP.MADECOUNT = t.MADECOUNT;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        public IHttpActionResult Delete(System.DateTime id)
        {

            using (var ctx = new BikeShopEntities())
            {
                var bp = ctx.TEMPDATEMADEs
                    .Where(w => w.DATEVALUE == id)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
