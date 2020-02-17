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
    public class TubeMaterialController : ApiController
    {
        public IHttpActionResult GetAllTubeMaterials()
        {
            IList<TubeMaterialViewModel> tubematerial = null;
            using (var ctx = new BikeShopEntities())
            {
                tubematerial = ctx.TUBEMATERIALs.Select(t => new TubeMaterialViewModel()
                {
                    TUBEID = t.TUBEID,
                    MATERIAL = t.MATERIAL,
                    DESCRIPTION = t.DESCRIPTION,
                    DIAMETER = t.DIAMETER,
                    THICKNESS = t.THICKNESS,
                    ROUNDNESS = t.ROUNDNESS,
                    WEIGHT = t.WEIGHT,
                    STIFFNESS = t.STIFFNESS,
                    LISTPRICE = t.LISTPRICE,
                    CONSTRUCTION = t.CONSTRUCTION
                }).ToList<TubeMaterialViewModel>();
            }
            if (tubematerial.Count == 0)
            {
                return NotFound();
            }

            return Ok(tubematerial);
        }
    }
}
