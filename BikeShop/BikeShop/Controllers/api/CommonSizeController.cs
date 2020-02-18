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
    public class CommonSizeController : ApiController
    {
        public IHttpActionResult GetAllCommonSizes()
        {
            IList<CommonSizeViewModel> commonsizes = null;
            using (var ctx = new BikeShopEntities())
            {
                commonsizes = ctx.COMMONSIZES.Select(c => new CommonSizeViewModel()
                {
                   MODELTYPE = c.MODELTYPE,
                   FRAMESIZE = c.FRAMESIZE
                }).ToList<CommonSizeViewModel>();
            }
            if (commonsizes.Count == 0)
            {
                return NotFound();
            }

            return Ok(commonsizes);
        }
    }
}
