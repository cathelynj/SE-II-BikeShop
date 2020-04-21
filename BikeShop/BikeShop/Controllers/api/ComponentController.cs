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
    public class ComponentController : ApiController
    {
        public IHttpActionResult GetAllComponents()
        {
            IList<ComponentViewModel> components = null;
            using (var ctx = new BikeShopEntities())
            {
                components = ctx.COMPONENTs.Select(c => new ComponentViewModel()
                {
                    COMPONENTID = c.COMPONENTID,
                    MANUFACTURERID = c.MANUFACTURERID,
                    PRODUCTNUMBER = c.PRODUCTNUMBER,
                    ROAD = c.ROAD,
                    CATEGORY = c.CATEGORY,
                    LENGTH = c.LENGTH,
                    HEIGHT = c.HEIGHT,
                    WIDTH = c.WIDTH,
                    WEIGHT = c.WEIGHT,
                    YEAR = c.YEAR,
                    ENDYEAR = c.ENDYEAR,
                    DESCRIPTION = c.DESCRIPTION,
                    LISTPRICE = c.LISTPRICE,
                    ESTIMATEDCOST = c.ESTIMATEDCOST,
                    QUANTITYONHAND = c.QUANTITYONHAND
                }).ToList<ComponentViewModel>();
            }
            if (components.Count == 0)
            {
                return NotFound();
            }

            return Ok(components);
        }

        public IHttpActionResult GetComponent(int id)
        {
            ComponentViewModel bikeParts = null;

            using (var ctx = new BikeShopEntities())
            {
                bikeParts = ctx.COMPONENTs
                    .Where(c => c.COMPONENTID == id)
                    .Select(c => new ComponentViewModel()
                    {
                        COMPONENTID = c.COMPONENTID,
                        MANUFACTURERID = c.MANUFACTURERID,
                        PRODUCTNUMBER = c.PRODUCTNUMBER,
                        ROAD = c.ROAD,
                        CATEGORY = c.CATEGORY,
                        LENGTH = c.LENGTH,
                        HEIGHT = c.HEIGHT,
                        WIDTH = c.WIDTH,
                        WEIGHT = c.WEIGHT,
                        YEAR = c.YEAR,
                        ENDYEAR = c.ENDYEAR,
                        DESCRIPTION = c.DESCRIPTION,
                        LISTPRICE = c.LISTPRICE,
                        ESTIMATEDCOST = c.ESTIMATEDCOST,
                        QUANTITYONHAND = c.QUANTITYONHAND
                    }).FirstOrDefault<ComponentViewModel>();
            }
            if (bikeParts == null)
            {
                return NotFound();
            }
            return Ok(bikeParts);
        }

        public IHttpActionResult PostNewComponent(ComponentViewModel c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.COMPONENTs.Add(new COMPONENT()
                {
                    COMPONENTID = c.COMPONENTID,
                    MANUFACTURERID = c.MANUFACTURERID,
                    PRODUCTNUMBER = c.PRODUCTNUMBER,
                    ROAD = c.ROAD,
                    CATEGORY = c.CATEGORY,
                    LENGTH = c.LENGTH,
                    HEIGHT = c.HEIGHT,
                    WIDTH = c.WIDTH,
                    WEIGHT = c.WEIGHT,
                    YEAR = c.YEAR,
                    ENDYEAR = c.ENDYEAR,
                    DESCRIPTION = c.DESCRIPTION,
                    LISTPRICE = c.LISTPRICE,
                    ESTIMATEDCOST = c.ESTIMATEDCOST,
                    QUANTITYONHAND = c.QUANTITYONHAND
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(ComponentViewModel c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingC = ctx.COMPONENTs.Where(w => w.COMPONENTID == c.COMPONENTID).FirstOrDefault<COMPONENT>();
                if (existingC != null)
                {
                    existingC.COMPONENTID = c.COMPONENTID;
                    existingC.MANUFACTURERID = c.MANUFACTURERID;
                    existingC.PRODUCTNUMBER = c.PRODUCTNUMBER;
                    existingC.ROAD = c.ROAD;
                    existingC.CATEGORY = c.CATEGORY;
                    existingC.LENGTH = c.LENGTH;
                    existingC.HEIGHT = c.HEIGHT;
                    existingC.WIDTH = c.WIDTH;
                    existingC.WEIGHT = c.WEIGHT;
                    existingC.YEAR = c.YEAR;
                    existingC.ENDYEAR = c.ENDYEAR;
                    existingC.DESCRIPTION = c.DESCRIPTION;
                    existingC.LISTPRICE = c.LISTPRICE;
                    existingC.ESTIMATEDCOST = c.ESTIMATEDCOST;
                    existingC.QUANTITYONHAND = c.QUANTITYONHAND;

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
                var bp = ctx.COMPONENTs
                    .Where(w => w.COMPONENTID == id)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
