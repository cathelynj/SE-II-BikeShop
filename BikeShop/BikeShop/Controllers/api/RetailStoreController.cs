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
    public class RetailStoreController : ApiController
    {
        public IHttpActionResult GetAllRetailStores()
        {
            IList<RetailStoreViewModel> retailstore = null;
            using (var ctx = new BikeShopEntities())
            {
                retailstore = ctx.RETAILSTOREs.Select(r => new RetailStoreViewModel()
                {
                    STOREID = r.STOREID,
                    STORENAME = r.STORENAME,
                    PHONE = r.PHONE,
                    CONTACTFIRSTNAME = r.CONTACTFIRSTNAME,
                    CONTACTLASTNAME = r.CONTACTLASTNAME,
                    ADDRESS = r.ADDRESS,
                    ZIPCODE = r.ZIPCODE,
                    CITYID = r.CITYID
                }).ToList<RetailStoreViewModel>();
            }
            if (retailstore.Count == 0)
            {
                return NotFound();
            }

            return Ok(retailstore);
        }
    }
}
