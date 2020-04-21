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
    public class BikeTubeController : ApiController
    {
        public IHttpActionResult GetAllBikeTubes()
        {
            IList<BikeTubesViewModel> bikeTubes = null;
            using (var ctx = new BikeShopEntities())
            {
                bikeTubes = ctx.BIKETUBES.Select(bt => new BikeTubesViewModel()
                {
                    SERIALNUMBER = bt.SERIALNUMBER,
                    TUBENAME = bt.TUBENAME,
                    TUBEID = bt.TUBEID,
                    LENGTH = bt.LENGTH
                }).ToList<BikeTubesViewModel>();
            }
            if (bikeTubes.Count == 0)
            {
                return NotFound();
            }

            return Ok(bikeTubes);
        }

        public IHttpActionResult GetBikeTube(int id, string tubeName)
        {
            BikeTubesViewModel bikeTubes  = null;

            using (var ctx = new BikeShopEntities())
            {
                bikeTubes = ctx.BIKETUBES
                    .Where(bt => bt.SERIALNUMBER == id && bt.TUBENAME == tubeName)
                    .Select(bt => new BikeTubesViewModel()
                    {
                        SERIALNUMBER = bt.SERIALNUMBER,
                        TUBENAME = bt.TUBENAME,
                        TUBEID = bt.TUBEID,
                        LENGTH = bt.LENGTH
                    }).FirstOrDefault<BikeTubesViewModel>();
            }
            if (bikeTubes == null)
            {
                return NotFound();
            }
            return Ok(bikeTubes);
        }

        public IHttpActionResult PostNewEmployee(BikeTubesViewModel bt)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.BIKETUBES.Add(new BIKETUBE()
                {
                    SERIALNUMBER = bt.SERIALNUMBER,
                    TUBENAME = bt.TUBENAME,
                    TUBEID = bt.TUBEID,
                    LENGTH = bt.LENGTH
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(BikeTubesViewModel bt)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.BIKETUBES.Where(w => w.SERIALNUMBER == bt.SERIALNUMBER && w.TUBENAME == bt.TUBENAME).FirstOrDefault<BIKETUBE>();
                if (existingBP != null)
                {
                    existingBP.SERIALNUMBER = bt.SERIALNUMBER;
                    existingBP.TUBENAME = bt.TUBENAME;
                    existingBP.TUBEID = bt.TUBEID;
                    existingBP.LENGTH = bt.LENGTH;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        public IHttpActionResult Delete(int serial, string tube)
        {

            using (var ctx = new BikeShopEntities())
            {
                var bp = ctx.BIKETUBES
                    .Where(w => w.SERIALNUMBER == serial && w.TUBENAME == tube)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
