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
    public class PurchaseItemController : ApiController
    {
        public IHttpActionResult GetAllPurchaseItems()
        {
            IList<PurchaseItemViewModel> purchaseitem = null;
            using (var ctx = new BikeShopEntities())
            {
                purchaseitem = ctx.PURCHASEITEMs.Select(p => new PurchaseItemViewModel()
                {
                    PURCHASEID = p.PURCHASEID,
                    COMPONENTID = p.COMPONENTID,
                    PRICEPAID = p.PRICEPAID,
                    QUANTITY = p.QUANTITY,
                    QUANTITYRECEIVED = p.QUANTITYRECEIVED
                }).ToList<PurchaseItemViewModel>();
            }
            if (purchaseitem.Count == 0)
            {
                return NotFound();
            }

            return Ok(purchaseitem);
        }
    }
}
