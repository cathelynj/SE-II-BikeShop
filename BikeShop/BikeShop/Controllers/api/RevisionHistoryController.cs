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
    public class RevisionHistoryController : ApiController
    {
        public IHttpActionResult GetAllRevisionHistories()
        {
            IList<RevisionHistoryViewModel> revisionhistory = null;
            using (var ctx = new BikeShopEntities())
            {
                revisionhistory = ctx.REVISIONHISTORies.Select(r => new RevisionHistoryViewModel()
                {
                    ID = r.ID,
                    VERSION = r.VERSION,
                    CHANGEDATE = r.CHANGEDATE,
                    NAME = r.NAME,
                    REVISIONCOMMENTS = r.REVISIONCOMMENTS
                }).ToList<RevisionHistoryViewModel>();
            }
            if (revisionhistory.Count == 0)
            {
                return NotFound();
            }

            return Ok(revisionhistory);
        }

        public IHttpActionResult GetRevisionHistory(int id)
        {
            RevisionHistoryViewModel revisionHistory = null;

            using (var ctx = new BikeShopEntities())
            {
                revisionHistory = ctx.REVISIONHISTORies
                    .Where(r => r.ID == id)
                    .Select(r => new RevisionHistoryViewModel()
                    {
                        ID = r.ID,
                        VERSION = r.VERSION,
                        CHANGEDATE = r.CHANGEDATE,
                        NAME = r.NAME,
                        REVISIONCOMMENTS = r.REVISIONCOMMENTS
                    }).FirstOrDefault<RevisionHistoryViewModel>();
            }
            if (revisionHistory == null)
            {
                return NotFound();
            }
            return Ok(revisionHistory);
        }

        public IHttpActionResult PostNewRevisionHistory(RevisionHistoryViewModel r)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.REVISIONHISTORies.Add(new REVISIONHISTORY()
                {
                    ID = r.ID,
                    VERSION = r.VERSION,
                    CHANGEDATE = r.CHANGEDATE,
                    NAME = r.NAME,
                    REVISIONCOMMENTS = r.REVISIONCOMMENTS
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(RevisionHistoryViewModel r)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.REVISIONHISTORies.Where(w => w.ID == r.ID).FirstOrDefault<REVISIONHISTORY>();
                if (existingBP != null)
                {
                    existingBP.ID = r.ID;
                    existingBP.VERSION = r.VERSION;
                    existingBP.CHANGEDATE = r.CHANGEDATE;
                    existingBP.NAME = r.NAME;
                    existingBP.REVISIONCOMMENTS = r.REVISIONCOMMENTS;

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
                var bp = ctx.REVISIONHISTORies
                    .Where(w => w.ID == id)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
