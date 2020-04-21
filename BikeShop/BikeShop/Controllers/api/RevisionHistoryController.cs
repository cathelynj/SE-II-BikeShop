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
    }
}
