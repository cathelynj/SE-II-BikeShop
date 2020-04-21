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
    public class TempDateMadeController : ApiController
    {
        public IHttpActionResult GetAllTempDateMade()
        {
            IList<TempDateMadeViewModel> datemade = null;
            using (var ctx = new BikeShopEntities())
            {
                datemade = ctx.TEMPDATEMADEs.Select(t => new TempDateMadeViewModel()
                {
                    DATEVALUE = t.DATEVALUE,
                    MADECOUNT = t.MADECOUNT
                }).ToList<TempDateMadeViewModel>();
            }
            if (datemade.Count == 0)
            {
                return NotFound();
            }

            return Ok(datemade);
        }
    }
}
