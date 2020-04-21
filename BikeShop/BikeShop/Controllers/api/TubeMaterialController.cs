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
    public class TubeMaterialController : ApiController
    {
        public IHttpActionResult GetAllTubeMaterials()
        {
            IList<TubeMaterialViewModel> tubematerial = null;
            using (var ctx = new BikeShopEntities())
            {
                tubematerial = ctx.TUBEMATERIALs.Select(t => new TubeMaterialViewModel()
                {
                    TUBEID = t.TUBEID,
                    MATERIAL = t.MATERIAL,
                    DESCRIPTION = t.DESCRIPTION,
                    DIAMETER = t.DIAMETER,
                    THICKNESS = t.THICKNESS,
                    ROUNDNESS = t.ROUNDNESS,
                    WEIGHT = t.WEIGHT,
                    STIFFNESS = t.STIFFNESS,
                    LISTPRICE = t.LISTPRICE,
                    CONSTRUCTION = t.CONSTRUCTION
                }).ToList<TubeMaterialViewModel>();
            }
            if (tubematerial.Count == 0)
            {
                return NotFound();
            }

            return Ok(tubematerial);
        }

        public IHttpActionResult GetTubeMaterial(int id)
        {
            TubeMaterialViewModel tm = null;

            using (var ctx = new BikeShopEntities())
            {
                tm = ctx.TUBEMATERIALs
                    .Where(t => t.TUBEID == id)
                    .Select(t => new TubeMaterialViewModel()
                    {
                        TUBEID = t.TUBEID,
                        MATERIAL = t.MATERIAL,
                        DESCRIPTION = t.DESCRIPTION,
                        DIAMETER = t.DIAMETER,
                        THICKNESS = t.THICKNESS,
                        ROUNDNESS = t.ROUNDNESS,
                        WEIGHT = t.WEIGHT,
                        STIFFNESS = t.STIFFNESS,
                        LISTPRICE = t.LISTPRICE,
                        CONSTRUCTION = t.CONSTRUCTION
                    }).FirstOrDefault<TubeMaterialViewModel>();
            }
            if (tm == null)
            {
                return NotFound();
            }
            return Ok(tm);
        }

        public IHttpActionResult PostNewTubeMaterial(TubeMaterialViewModel t)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.TUBEMATERIALs.Add(new TUBEMATERIAL()
                {
                    TUBEID = t.TUBEID,
                    MATERIAL = t.MATERIAL,
                    DESCRIPTION = t.DESCRIPTION,
                    DIAMETER = t.DIAMETER,
                    THICKNESS = t.THICKNESS,
                    ROUNDNESS = t.ROUNDNESS,
                    WEIGHT = t.WEIGHT,
                    STIFFNESS = t.STIFFNESS,
                    LISTPRICE = t.LISTPRICE,
                    CONSTRUCTION = t.CONSTRUCTION
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(TubeMaterialViewModel t)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.TUBEMATERIALs.Where(w => w.TUBEID == t.TUBEID).FirstOrDefault<TUBEMATERIAL>();
                if (existingBP != null)
                {
                    existingBP.TUBEID = t.TUBEID;
                    existingBP.MATERIAL = t.MATERIAL;
                    existingBP.DESCRIPTION = t.DESCRIPTION;
                    existingBP.DIAMETER = t.DIAMETER;
                    existingBP.THICKNESS = t.THICKNESS;
                    existingBP.ROUNDNESS = t.ROUNDNESS;
                    existingBP.WEIGHT = t.WEIGHT;
                    existingBP.STIFFNESS = t.STIFFNESS;
                    existingBP.LISTPRICE = t.LISTPRICE;
                    existingBP.CONSTRUCTION = t.CONSTRUCTION;

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
                var bp = ctx.TUBEMATERIALs
                    .Where(w => w.TUBEID == id)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
