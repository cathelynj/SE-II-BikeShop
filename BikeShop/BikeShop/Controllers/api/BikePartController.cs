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
    public class BikePartController : ApiController
    {
        public IHttpActionResult GetAllBikeParts()
        {
            IList<BikePartsViewModel> bikeParts = null;
            using (var ctx = new BikeShopEntities())
            {
                bikeParts = ctx.BIKEPARTS.Select(bp => new BikePartsViewModel()
                {
                    SERIALNUMBER = bp.SERIALNUMBER,
                    COMPONENTID = bp.COMPONENTID,
                    SUBSTITUTEID = bp.SUBSTITUTEID,
                    LOCATION = bp.LOCATION,
                    QUANTITY = bp.QUANTITY,
                    DATEINSTALLED = bp.DATEINSTALLED,
                    EMPLOYEEID = bp.EMPLOYEEID
                }).ToList<BikePartsViewModel>();
            }
            if (bikeParts.Count == 0)
            {
                return NotFound();
            }

            return Ok(bikeParts);
        }

        public IHttpActionResult GetBikePart(int serialNumber, int componentID)
        {
            BikePartsViewModel bikeParts = null;

            using (var ctx = new BikeShopEntities())
            {
                bikeParts = ctx.BIKEPARTS
                    .Where(bp => bp.SERIALNUMBER == serialNumber && bp.COMPONENTID == componentID)
                    .Select(bp => new BikePartsViewModel()
                    {
                        SERIALNUMBER = bp.SERIALNUMBER,
                        COMPONENTID = bp.COMPONENTID,
                        SUBSTITUTEID = bp.SUBSTITUTEID,
                        LOCATION = bp.LOCATION,
                        QUANTITY = bp.QUANTITY,
                        DATEINSTALLED = bp.DATEINSTALLED,
                        EMPLOYEEID = bp.EMPLOYEEID
                    }).FirstOrDefault<BikePartsViewModel>();
            }
            if (bikeParts == null)
            {
                return NotFound();
            }
            return Ok(bikeParts);
        }

        public IHttpActionResult PostNewBikePart(BikePartsViewModel bp)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.BIKEPARTS.Add(new BIKEPART()
                {
                    SERIALNUMBER = bp.SERIALNUMBER,
                    COMPONENTID = bp.COMPONENTID,
                    SUBSTITUTEID = bp.SUBSTITUTEID,
                    LOCATION = bp.LOCATION,
                    QUANTITY = bp.QUANTITY,
                    DATEINSTALLED = bp.DATEINSTALLED,
                    EMPLOYEEID = bp.EMPLOYEEID
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(BikePartsViewModel bp)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.BIKEPARTS.Where(w => w.SERIALNUMBER == bp.SERIALNUMBER && w.COMPONENTID == bp.COMPONENTID).FirstOrDefault<BIKEPART>();
                if (existingBP != null)
                {
                    existingBP.SERIALNUMBER = bp.SERIALNUMBER;
                    existingBP.COMPONENTID = bp.COMPONENTID;
                    existingBP.SUBSTITUTEID = bp.SUBSTITUTEID;
                    existingBP.LOCATION = bp.LOCATION;
                    existingBP.QUANTITY = bp.QUANTITY;
                    existingBP.DATEINSTALLED = bp.DATEINSTALLED;
                    existingBP.EMPLOYEEID = bp.EMPLOYEEID;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        public IHttpActionResult Delete(int serial, int comp)
        {

            using (var ctx = new BikeShopEntities())
            {
                var bp = ctx.BIKEPARTS
                    .Where(w => w.SERIALNUMBER == serial && w.COMPONENTID == comp)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
