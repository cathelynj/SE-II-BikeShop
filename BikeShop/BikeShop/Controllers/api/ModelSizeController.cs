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
    public class ModelSizeController : ApiController
    {
        public IHttpActionResult GetAllModelSizes()
        {
            IList<ModelSizeViewModel> modelsize = null;
            using (var ctx = new BikeShopEntities())
            {
                modelsize = ctx.MODELSIZEs.Select(m => new ModelSizeViewModel()
                {
                    MODELTYPE = m.MODELTYPE,
                    MSIZE = m.MSIZE,
                    TOPTUBE = m.TOPTUBE,
                    CHAINSTAY = m.CHAINSTAY,
                    TOTALLENGTH = m.TOTALLENGTH,
                    GROUNDCLEARANCE = m.GROUNDCLEARANCE,
                    HEADTUBEANGLE = m.HEADTUBEANGLE,
                    SEATTUBEANGLE = m.SEATTUBEANGLE
                }).ToList<ModelSizeViewModel>();
            }
            if (modelsize.Count == 0)
            {
                return NotFound();
            }

            return Ok(modelsize);
        }

        public IHttpActionResult GetModelSize(string type, int size)
        {
            ModelSizeViewModel modelSize = null;

            using (var ctx = new BikeShopEntities())
            {
                modelSize = ctx.MODELSIZEs
                    .Where(m => m.MODELTYPE == type && m.MSIZE == size)
                    .Select(m => new ModelSizeViewModel()
                    {
                        MODELTYPE = m.MODELTYPE,
                        MSIZE = m.MSIZE,
                        TOPTUBE = m.TOPTUBE,
                        CHAINSTAY = m.CHAINSTAY,
                        TOTALLENGTH = m.TOTALLENGTH,
                        GROUNDCLEARANCE = m.GROUNDCLEARANCE,
                        HEADTUBEANGLE = m.HEADTUBEANGLE,
                        SEATTUBEANGLE = m.SEATTUBEANGLE
                    }).FirstOrDefault<ModelSizeViewModel>();
            }
            if (modelSize == null)
            {
                return NotFound();
            }
            return Ok(modelSize);
        }

        public IHttpActionResult PostNewModelSize(ModelSizeViewModel m)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.MODELSIZEs.Add(new MODELSIZE()
                {
                    MODELTYPE = m.MODELTYPE,
                    MSIZE = m.MSIZE,
                    TOPTUBE = m.TOPTUBE,
                    CHAINSTAY = m.CHAINSTAY,
                    TOTALLENGTH = m.TOTALLENGTH,
                    GROUNDCLEARANCE = m.GROUNDCLEARANCE,
                    HEADTUBEANGLE = m.HEADTUBEANGLE,
                    SEATTUBEANGLE = m.SEATTUBEANGLE
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(ModelSizeViewModel m)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.MODELSIZEs.Where(w => w.MODELTYPE == m.MODELTYPE && w.MSIZE == m.MSIZE).FirstOrDefault<MODELSIZE>();
                if (existingBP != null)
                {
                    existingBP.MODELTYPE = m.MODELTYPE;
                    existingBP.MSIZE = m.MSIZE;
                    existingBP.TOPTUBE = m.TOPTUBE;
                    existingBP.CHAINSTAY = m.CHAINSTAY;
                    existingBP.TOTALLENGTH = m.TOTALLENGTH;
                    existingBP.GROUNDCLEARANCE = m.GROUNDCLEARANCE;
                    existingBP.HEADTUBEANGLE = m.HEADTUBEANGLE;
                    existingBP.SEATTUBEANGLE = m.SEATTUBEANGLE;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        public IHttpActionResult Delete(string type, int size)
        {

            using (var ctx = new BikeShopEntities())
            {
                var bp = ctx.MODELSIZEs
                    .Where(w => w.MODELTYPE == type && w.MSIZE == size)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
