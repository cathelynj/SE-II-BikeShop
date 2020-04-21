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
    public class PaintController : ApiController
    {
        public IHttpActionResult GetAllPaint()
        {
            IList<PaintViewModel> paint = null;
            using (var ctx = new BikeShopEntities())
            {
                paint = ctx.PAINTs.Select(c => new PaintViewModel()
                {
                    PaintID = c.PAINTID,
                    ColorName = c.COLORNAME,
                    ColorStyle = c.COLORSTYLE,
                    ColorList = c.COLORLIST,
                    DateIntroduced = c.DATEINTRODUCED,
                    DateDiscontinued = c.DATEDISCONTINUED

                }).ToList<PaintViewModel>();
            }
            if (paint.Count == 0)
            {
                return NotFound();
            }

            return Ok(paint);
        }

        public IHttpActionResult GetPaint(int id)
        {
            PaintViewModel p = null;

            using (var ctx = new BikeShopEntities())
            {
                p = ctx.PAINTs
                    .Where(c => c.PAINTID == id)
                    .Select(c => new PaintViewModel()
                    {
                        PaintID = c.PAINTID,
                        ColorName = c.COLORNAME,
                        ColorStyle = c.COLORSTYLE,
                        ColorList = c.COLORLIST,
                        DateIntroduced = c.DATEINTRODUCED,
                        DateDiscontinued = c.DATEDISCONTINUED
                    }).FirstOrDefault<PaintViewModel>();
            }
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        public IHttpActionResult PostNewPaint(PaintViewModel c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.PAINTs.Add(new PAINT()
                {
                    PAINTID = c.PaintID,
                    COLORNAME = c.ColorName,
                    COLORSTYLE = c.ColorStyle,
                    COLORLIST = c.ColorList,
                    DATEINTRODUCED = c.DateIntroduced,
                    DATEDISCONTINUED = c.DateDiscontinued
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(PaintViewModel c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.PAINTs.Where(w => w.PAINTID == c.PaintID).FirstOrDefault<PAINT>();
                if (existingBP != null)
                {
                    existingBP.PAINTID = c.PaintID;
                    existingBP.COLORNAME = c.ColorName;
                    existingBP.COLORSTYLE = c.ColorStyle;
                    existingBP.COLORLIST = c.ColorList;
                    existingBP.DATEINTRODUCED = c.DateIntroduced;
                    existingBP.DATEDISCONTINUED = c.DateDiscontinued;

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
                var bp = ctx.PAINTs
                    .Where(w => w.PAINTID == id)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
