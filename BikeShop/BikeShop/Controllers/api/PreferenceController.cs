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
    public class PreferenceController : ApiController
    {
        public class GroupOController : ApiController
        {
            public IHttpActionResult GetAllPreferences()
            {
                IList<PreferenceViewModel> preference = null;
                using (var ctx = new BikeShopEntities())
                {
                    preference = ctx.PREFERENCEs.Select(c => new PreferenceViewModel()
                    {
                        ItemName = c.ITEMNAME,
                        Value = c.VALUE,
                        Description = c.DESCRIPTION,
                        DateChanged = c.DATECHANGED

                    }).ToList<PreferenceViewModel>();
                }
                if (preference.Count == 0)
                {
                    return NotFound();
                }

                return Ok(preference);
            }

            public IHttpActionResult GetPreference(string item)
            {
                PreferenceViewModel bikeParts = null;

                using (var ctx = new BikeShopEntities())
                {
                    bikeParts = ctx.PREFERENCEs
                        .Where(c => c.ITEMNAME == item)
                        .Select(c => new PreferenceViewModel()
                        {
                            ItemName = c.ITEMNAME,
                            Value = c.VALUE,
                            Description = c.DESCRIPTION,
                            DateChanged = c.DATECHANGED
                        }).FirstOrDefault<PreferenceViewModel>();
                }
                if (bikeParts == null)
                {
                    return NotFound();
                }
                return Ok(bikeParts);
            }

            public IHttpActionResult PostNewPreference(PreferenceViewModel c)
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                using (var ctx = new BikeShopEntities())
                {
                    ctx.PREFERENCEs.Add(new PREFERENCE()
                    {
                        ITEMNAME = c.ItemName,
                        VALUE = c.Value,
                        DESCRIPTION = c.Description,
                        DATECHANGED = c.DateChanged
                    });

                    ctx.SaveChanges();
                }
                return Ok();
            }

            public IHttpActionResult Put(PreferenceViewModel c)
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");
                using (var ctx = new BikeShopEntities())
                {
                    var existingBP = ctx.PREFERENCEs.Where(w => w.ITEMNAME == c.ItemName).FirstOrDefault<PREFERENCE>();
                    if (existingBP != null)
                    {
                        existingBP.ITEMNAME = c.ItemName;
                        existingBP.VALUE = c.Value;
                        existingBP.DESCRIPTION = c.Description;
                        existingBP.DATECHANGED = c.DateChanged;

                        ctx.SaveChanges();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return Ok();
            }

            public IHttpActionResult Delete(string item)
            {

                using (var ctx = new BikeShopEntities())
                {
                    var bp = ctx.PREFERENCEs
                        .Where(w => w.ITEMNAME == item)
                        .FirstOrDefault();

                    ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                    ctx.SaveChanges();
                }
                return Ok();
            }
        }
    }
}