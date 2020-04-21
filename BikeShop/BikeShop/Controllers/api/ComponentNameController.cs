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
    public class ComponentNameController : ApiController
    {
        public IHttpActionResult GetAllComponentNames()
        {
            IList<ComponentNameViewModel> componentname = null;
            using (var ctx = new BikeShopEntities())
            {
                componentname = ctx.COMPONENTNAMEs.Select(c => new ComponentNameViewModel()
                {
                    COMPONENTNAME1 = c.COMPONENTNAME1,
                    ASSEMBLYORDER = c.ASSEMBLYORDER,
                    DESCRIPTION = c.DESCRIPTION
                }).ToList<ComponentNameViewModel>();
            }
            if (componentname.Count == 0)
            {
                return NotFound();
            }

            return Ok(componentname);
        }

        public IHttpActionResult GetComponentName(string id)
        {
            ComponentNameViewModel cn = null;

            using (var ctx = new BikeShopEntities())
            {
                cn = ctx.COMPONENTNAMEs
                    .Where(c => c.COMPONENTNAME1 == id)
                    .Select(c => new ComponentNameViewModel()
                    {
                        COMPONENTNAME1 = c.COMPONENTNAME1,
                        ASSEMBLYORDER = c.ASSEMBLYORDER,
                        DESCRIPTION = c.DESCRIPTION
                    }).FirstOrDefault<ComponentNameViewModel>();
            }
            if (cn == null)
            {
                return NotFound();
            }
            return Ok(cn);
        }

        public IHttpActionResult PostNewBikePart(ComponentNameViewModel c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.COMPONENTNAMEs.Add(new COMPONENTNAME()
                {
                    COMPONENTNAME1 = c.COMPONENTNAME1,
                    ASSEMBLYORDER = c.ASSEMBLYORDER,
                    DESCRIPTION = c.DESCRIPTION
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(ComponentNameViewModel c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.COMPONENTNAMEs.Where(w => w.COMPONENTNAME1 == c.COMPONENTNAME1).FirstOrDefault<COMPONENTNAME>();
                if (existingBP != null)
                {
                    existingBP.COMPONENTNAME1 = c.COMPONENTNAME1;
                    existingBP.ASSEMBLYORDER = c.ASSEMBLYORDER;
                    existingBP.DESCRIPTION = c.DESCRIPTION;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        public IHttpActionResult Delete(string id)
        {

            using (var ctx = new BikeShopEntities())
            {
                var bp = ctx.COMPONENTNAMEs
                    .Where(w => w.COMPONENTNAME1 == id)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
