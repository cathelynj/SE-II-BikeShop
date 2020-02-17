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
    public class PurchaseOrderController : ApiController
    {
        public IHttpActionResult GetAllPurchaseOrders()
        {
            IList<PurchaseOrderViewModel> purchaseorder = null;
            using (var ctx = new BikeShopEntities())
            {
                purchaseorder = ctx.PURCHASEORDERs.Select(p => new PurchaseOrderViewModel()
                {
                    PURCHASEID = p.PURCHASEID,
                    EMPLOYEEID = p.EMPLOYEEID,
                    MANUFACTURERID = p.MANUFACTURERID,
                    TOTALLIST = p.TOTALLIST,
                    SHIPPINGCOST = p.SHIPPINGCOST,
                    DISCOUNT = p.DISCOUNT,
                    ORDERDATE = p.ORDERDATE,
                    RECEIVEDATE = p.RECEIVEDATE,
                    AMOUNTDUE = p.AMOUNTDUE
                }).ToList<PurchaseOrderViewModel>();
            }
            if (purchaseorder.Count == 0)
            {
                return NotFound();
            }

            return Ok(purchaseorder);
        }
    }
}
