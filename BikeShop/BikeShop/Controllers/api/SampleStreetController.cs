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
    public class SampleStreetController : ApiController
    {
        public IHttpActionResult GetAllSampleStreets()
        {
            IList<SampleStreetViewModel> samplestreet = null;
            using (var ctx = new BikeShopEntities())
            {
                samplestreet = ctx.SAMPLESTREETs.Select(s => new SampleStreetViewModel()
                {
                    ID = s.ID,
                    BASEADDRESS = s.BASEADDRESS
                }).ToList<SampleStreetViewModel>();
            }
            if (samplestreet.Count == 0)
            {
                return NotFound();
            }

            return Ok(samplestreet);
        }

        public IHttpActionResult GetSampleStreet(int id)
        {
            SampleStreetViewModel s = null;

            using (var ctx = new BikeShopEntities())
            {
                s = ctx.SAMPLESTREETs
                    .Where(ss => ss.ID == id)
                    .Select(ss => new SampleStreetViewModel()
                    {
                        ID = ss.ID,
                        BASEADDRESS = ss.BASEADDRESS
                    }).FirstOrDefault<SampleStreetViewModel>();
            }
            if (s == null)
            {
                return NotFound();
            }
            return Ok(s);
        }

        public IHttpActionResult PostNewSampleStreet(SampleStreetViewModel bp)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.SAMPLESTREETs.Add(new SAMPLESTREET()
                {
                    ID = bp.ID,
                    BASEADDRESS = bp.BASEADDRESS
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(SampleStreetViewModel bp)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.SAMPLESTREETs.Where(w => w.ID == bp.ID).FirstOrDefault<SAMPLESTREET>();
                if (existingBP != null)
                {
                    existingBP.ID = bp.ID;
                    existingBP.BASEADDRESS = bp.BASEADDRESS;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {

            using (var ctx = new BikeShopEntities())
            {
                var bp = ctx.SAMPLESTREETs
                    .Where(w => w.ID == id)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
