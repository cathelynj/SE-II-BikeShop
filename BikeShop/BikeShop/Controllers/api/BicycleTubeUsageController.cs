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

        public IHttpActionResult GetBicycleTubeUsage(int id)
        {
            BicycleTubeUsageViewModel bicycleTubeUsage = null;

            using (var ctx = new BikeShopEntities())
            {
                bicycleTubeUsage = ctx.BICYCLETUBEUSAGEs
                    .Where(btu => btu.SERIALNUMBER == id)
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
    }
}
