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
    public class ComponentController : ApiController
    {
        public IHttpActionResult GetAllComponents()
        {
            IList<ComponentViewModel> components = null;
            using (var ctx = new BikeShopEntities())
            {
                components = ctx.COMPONENTs.Select(c => new ComponentViewModel()
                {
                    COMPONENTID = c.COMPONENTID,
                    MANUFACTURERID = c.MANUFACTURERID,
                    PRODUCTNUMBER = c.PRODUCTNUMBER,
                    ROAD = c.ROAD,
                    CATEGORY = c.CATEGORY,
                    LENGTH = c.LENGTH,
                    HEIGHT = c.HEIGHT,
                    WIDTH = c.WIDTH,
                    WEIGHT = c.WEIGHT,
                    YEAR = c.YEAR,
                    ENDYEAR = c.ENDYEAR,
                    DESCRIPTION = c.DESCRIPTION,
                    LISTPRICE = c.LISTPRICE,
                    ESTIMATEDCOST = c.ESTIMATEDCOST,
                    QUANTITYONHAND = c.QUANTITYONHAND
                }).ToList<ComponentViewModel>();
            }
            if (components.Count == 0)
            {
                return NotFound();
            }

            return Ok(componentsizes);
        }
    }
}
