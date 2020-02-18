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
    public class SampleStreetController : ApiController
    {
        public IHttpActionResult GetAllSampleStreets()
        {
            IList<SampleStreetViewModel> samplestreet = null;
            using (var ctx = new BikeShopEntities())
            {
                samplestreet = ctx.SAMPLESTREETs.Select(s => new SampleStreetViewModel()
                {
                    ID = s.ID,
                    BASEADDRESS = s.BASEADDRESS
                }).ToList<SampleStreetViewModel>();
            }
            if (samplestreet.Count == 0)
            {
                return NotFound();
            }

            return Ok(samplestreet);
        }
    }
}
