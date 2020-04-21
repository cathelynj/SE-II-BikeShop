using BikeShop.Models;
using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BikeShop.Controllers
{
    public class LetterStyleController : ApiController
    {
        public IHttpActionResult GetAllLetterStyle()
        {
            IList<LetterStyleViewModel> group = null;
            using (var ctx = new BikeShopEntities())
            {
                group = ctx.LETTERSTYLEs.Select(c => new LetterStyleViewModel()
                {
                   LetterStyle1 = c.LETTERSTYLE1,
                   Description = c.DESCRIPTION

                }).ToList<LetterStyleViewModel>();
            }
            if (group.Count == 0)
            {
                return NotFound();
            }

            return Ok(group);
        }

        public IHttpActionResult GetLetterstyle(string style)
        {
            LetterStyleViewModel letter = null;

            using (var ctx = new BikeShopEntities())
            {
                letter = ctx.LETTERSTYLEs
                    .Where(c => c.LETTERSTYLE1 == style)
                    .Select(c => new LetterStyleViewModel()
                    {
                        LetterStyle1 = c.LETTERSTYLE1,
                        Description = c.DESCRIPTION
                    }).FirstOrDefault<LetterStyleViewModel>();
            }
            if (letter == null)
            {
                return NotFound();
            }
            return Ok(letter);
        }

        public IHttpActionResult PostNewBikePart(LetterStyleViewModel c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.LETTERSTYLEs.Add(new LETTERSTYLE()
                {
                    LETTERSTYLE1 = c.LetterStyle1,
                    DESCRIPTION = c.Description
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(LetterStyleViewModel c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.LETTERSTYLEs.Where(w => w.LETTERSTYLE1 == c.LetterStyle1).FirstOrDefault<LETTERSTYLE>();
                if (existingBP != null)
                {
                    existingBP.LETTERSTYLE1 = c.LetterStyle1;
                    existingBP.DESCRIPTION = c.Description;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        public IHttpActionResult Delete(string style)
        {

            using (var ctx = new BikeShopEntities())
            {
                var bp = ctx.LETTERSTYLEs
                    .Where(w => w.LETTERSTYLE1 == style)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }

    } 
}
