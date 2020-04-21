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
    public class ModelTypeController : ApiController
    {
        public IHttpActionResult GetAllModels()
        {
            IList<ModelTypeViewModel> modeltype = null;
            using (var ctx = new BikeShopEntities())
            {
                modeltype = ctx.MODELTYPEs.Select(m => new ModelTypeViewModel()
                {
                    MODELTYPE1 = m.MODELTYPE1,
                    DESCRIPTION = m.DESCRIPTION,
                    COMPONENTID = m.COMPONENTID
                }).ToList<ModelTypeViewModel>();
            }
            if (modeltype.Count == 0)
            {
                return NotFound();
            }

            return Ok(modeltype);
        }
    }
}
