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
    public class SampleNameController : ApiController
    {
        public IHttpActionResult GetAllSampleNames()
        {
            IList<SampleNameViewModel> samplename = null;
            using (var ctx = new BikeShopEntities())
            {
                samplename = ctx.SAMPLENAMEs.Select(s => new SampleNameViewModel()
                {
                   ID = s.ID,
                   FIRSTNAME = s.FIRSTNAME,
                   LASTNAME = s.LASTNAME,
                   GENDER = s.GENDER
                }).ToList<SampleNameViewModel>();
            }
            if (samplename.Count == 0)
            {
                return NotFound();
            }

            return Ok(samplename);
        }
    }
}
