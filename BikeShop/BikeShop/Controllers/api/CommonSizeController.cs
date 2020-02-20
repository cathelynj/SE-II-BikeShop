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
    public class CommonSizeController : ApiController
    {
        public IHttpActionResult GetAllCommonSizes()
        {
            IList<CommonSizeViewModel> commonsizes = null;
            using (var ctx = new BikeShopEntities())
            {
                commonsizes = ctx.COMMONSIZES.Select(c => new CommonSizeViewModel()
                {
                   MODELTYPE = c.MODELTYPE,
                   FRAMESIZE = c.FRAMESIZE
                }).ToList<CommonSizeViewModel>();
            }
            if (commonsizes.Count == 0)
            {
                return NotFound();
            }

            return Ok(commonsizes);
        }

        public IHttpActionResult GetCommonSize(string model, int frame)
        {
            CommonSizeViewModel cs = null;

            using (var ctx = new BikeShopEntities())
            {
                cs = ctx.COMMONSIZES
                    .Where(c => c.MODELTYPE == model && c.FRAMESIZE == frame)
                    .Select(c => new CommonSizeViewModel()
                    {
                        MODELTYPE = c.MODELTYPE,
                        FRAMESIZE = c.FRAMESIZE
                    }).FirstOrDefault<CommonSizeViewModel>();
            }
            if (cs == null)
            {
                return NotFound();
            }
            return Ok(cs);
        }

        public IHttpActionResult PostNewBikePart(CommonSizeViewModel c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.COMMONSIZES.Add(new COMMONSIZE()
                {
                    MODELTYPE = c.MODELTYPE,
                    FRAMESIZE = c.FRAMESIZE
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        //No need for PUT as the only fields in table are both primary keys, and cannot be modified.

        public IHttpActionResult Delete(string modelType, int frameSize)
        {

            using (var ctx = new BikeShopEntities())
            {
                var bp = ctx.COMMONSIZES
                    .Where(w => w.MODELTYPE == modelType && w.FRAMESIZE == frameSize)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
