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
    public class StateTaxRateController : ApiController
    {
        public IHttpActionResult GetAllStateTaxRates()
        {
            IList<StateTaxRateViewModel> taxrate = null;
            using (var ctx = new BikeShopEntities())
            {
                taxrate = ctx.STATETAXRATEs.Select(s => new StateTaxRateViewModel()
                {
                   STATE = s.STATE,
                   TAXRATE = s.TAXRATE
                }).ToList<StateTaxRateViewModel>();
            }
            if (taxrate.Count == 0)
            {
                return NotFound();
            }

            return Ok(taxrate);
        }
    }
}
