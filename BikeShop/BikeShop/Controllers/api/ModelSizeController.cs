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
    public class ModelSizeController : ApiController
    {
        public IHttpActionResult GetAllModelSizes()
        {
            IList<ModelSizeViewModel> modelsize = null;
            using (var ctx = new BikeShopEntities())
            {
                modelsize = ctx.MODELSIZEs.Select(m => new ModelSizeViewModel()
                {
                    MODELTYPE = m.MODELTYPE,
                    MSIZE = m.MSIZE,
                    TOPTUBE = m.TOPTUBE,
                    CHAINSTAY = m.CHAINSTAY,
                    TOTALLENGTH = m.TOTALLENGTH,
                    GROUNDCLEARANCE = m.GROUNDCLEARANCE,
                    HEADTUBEANGLE = m.HEADTUBEANGLE,
                    SEATTUBEANGLE = m.SEATTUBEANGLE
                }).ToList<ModelSizeViewModel>();
            }
            if (modelsize.Count == 0)
            {
                return NotFound();
            }

            return Ok(modelsize);
        }
    }
}
