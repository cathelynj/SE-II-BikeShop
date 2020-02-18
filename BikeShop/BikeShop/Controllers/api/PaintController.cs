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
    }
}
