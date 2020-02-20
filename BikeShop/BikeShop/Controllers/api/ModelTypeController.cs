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
    public class ModelTypeController : ApiController
    {
        public IHttpActionResult GetAllModels()
        {
            IList<ModelTypeViewModel> modeltype = null;
            using (var ctx = new BikeShopEntities())
            {
                modeltype = ctx.MODELTYPEs.Select(m => new ModelTypeViewModel()
                {
                    MODELTYPE1 = m.MODELTYPE1,
                    DESCRIPTION = m.DESCRIPTION,
                    COMPONENTID = m.COMPONENTID
                }).ToList<ModelTypeViewModel>();
            }
            if (modeltype.Count == 0)
            {
                return NotFound();
            }

            return Ok(modeltype);
        }

        public IHttpActionResult GetModelType(string type)
        {
            ModelTypeViewModel mt = null;

            using (var ctx = new BikeShopEntities())
            {
                mt = ctx.MODELTYPEs
                    .Where(m => m.MODELTYPE1 == type)
                    .Select(m => new ModelTypeViewModel()
                    {
                        MODELTYPE1 = m.MODELTYPE1,
                        DESCRIPTION = m.DESCRIPTION,
                        COMPONENTID = m.COMPONENTID
                    }).FirstOrDefault<ModelTypeViewModel>();
            }
            if (mt == null)
            {
                return NotFound();
            }
            return Ok(mt);
        }

        public IHttpActionResult PostNewBikePart(ModelTypeViewModel m)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.MODELTYPEs.Add(new MODELTYPE()
                {
                    MODELTYPE1 = m.MODELTYPE1,
                    DESCRIPTION = m.DESCRIPTION,
                    COMPONENTID = m.COMPONENTID
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(ModelTypeViewModel m)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.MODELTYPEs.Where(w => w.MODELTYPE1 == m.MODELTYPE1).FirstOrDefault<MODELTYPE>();
                if (existingBP != null)
                {
                    existingBP.MODELTYPE1 = m.MODELTYPE1;
                    existingBP.DESCRIPTION = m.DESCRIPTION;
                    existingBP.COMPONENTID = m.COMPONENTID;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        public IHttpActionResult Delete(string type)
        {

            using (var ctx = new BikeShopEntities())
            {
                var bp = ctx.MODELTYPEs
                    .Where(w => w.MODELTYPE1 == type)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
