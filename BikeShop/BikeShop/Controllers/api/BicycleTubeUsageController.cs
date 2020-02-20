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
    public class BicycleTubeUsageController : ApiController
    {
        public IHttpActionResult GetAllBicycleTubeUsage()
        {
            IList<BicycleTubeUsageViewModel> bicycleTubeUsages = null;
            using (var ctx = new BikeShopEntities())
            {
                bicycleTubeUsages = ctx.BICYCLETUBEUSAGEs.Select(btu => new BicycleTubeUsageViewModel()
                {
                    SERIALNUMBER = btu.SERIALNUMBER,
                    TUBEID = btu.TUBEID,
                    QUANTITY = btu.QUANTITY
                }).ToList<BicycleTubeUsageViewModel>();
            }
            if (bicycleTubeUsages.Count == 0)
            {
                return NotFound();
            }

            return Ok(bicycleTubeUsages);
        }

        public IHttpActionResult GetBicycleTubeUsage(int serial, int tube)
        {
            BicycleTubeUsageViewModel bicycleTubeUsage = null;

            using (var ctx = new BikeShopEntities())
            {
                bicycleTubeUsage = ctx.BICYCLETUBEUSAGEs
                    .Where(btu => btu.SERIALNUMBER == serial && btu.TUBEID == tube)
                    .Select(btu => new BicycleTubeUsageViewModel()
                    {
                        SERIALNUMBER = btu.SERIALNUMBER,
                        TUBEID = btu.TUBEID,
                        QUANTITY = btu.QUANTITY
                    }).FirstOrDefault<BicycleTubeUsageViewModel>();
            }
            if (bicycleTubeUsage == null)
            {
                return NotFound();
            }
            return Ok(bicycleTubeUsage);
        }

        public IHttpActionResult PostNewBicycleTubeUsage(BicycleTubeUsageViewModel btu)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.BICYCLETUBEUSAGEs.Add(new BICYCLETUBEUSAGE()
                {
                    SERIALNUMBER = btu.SERIALNUMBER,
                    TUBEID = btu.TUBEID,
                    QUANTITY = btu.QUANTITY
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(BicycleTubeUsageViewModel btu)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBTU = ctx.BICYCLETUBEUSAGEs.Where(b => b.SERIALNUMBER == btu.SERIALNUMBER && b.TUBEID == btu.TUBEID).FirstOrDefault<BICYCLETUBEUSAGE>();
                if (existingBTU != null)
                {
                    existingBTU.SERIALNUMBER = btu.SERIALNUMBER;
                    existingBTU.TUBEID = btu.TUBEID;
                    existingBTU.QUANTITY = btu.QUANTITY;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        public IHttpActionResult Delete(int serial, int tube)
        {

            using (var ctx = new BikeShopEntities())
            {
                var btu = ctx.BICYCLETUBEUSAGEs
                    .Where(b => b.SERIALNUMBER == serial && b.TUBEID == tube)
                    .FirstOrDefault();

                ctx.Entry(btu).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
