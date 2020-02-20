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

        public IHttpActionResult GetPurchaseOrder(int id)
        {
            PurchaseOrderViewModel p = null;

            using (var ctx = new BikeShopEntities())
            {
                p = ctx.PURCHASEORDERs
                    .Where(bp => bp.PURCHASEID == id)
                    .Select(bp => new PurchaseOrderViewModel()
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
                    }).FirstOrDefault<PurchaseOrderViewModel>();
            }
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        public IHttpActionResult PostNewBikePart(PurchaseOrderViewModel p)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.PURCHASEORDERs.Add(new PURCHASEORDER()
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
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(PurchaseOrderViewModel p)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.PURCHASEORDERs.Where(w => w.PURCHASEID == p.PURCHASEID).FirstOrDefault<PURCHASEORDER>();
                if (existingBP != null)
                {
                    existingBP.PURCHASEID = p.PURCHASEID;
                    existingBP.EMPLOYEEID = p.EMPLOYEEID;
                    existingBP.MANUFACTURERID = p.MANUFACTURERID;
                    existingBP.TOTALLIST = p.TOTALLIST;
                    existingBP.SHIPPINGCOST = p.SHIPPINGCOST;
                    existingBP.DISCOUNT = p.DISCOUNT;
                    existingBP.ORDERDATE = p.ORDERDATE;
                    existingBP.RECEIVEDATE = p.RECEIVEDATE;
                    existingBP.AMOUNTDUE = p.AMOUNTDUE;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {

            using (var ctx = new BikeShopEntities())
            {
                var bp = ctx.PURCHASEORDERs
                    .Where(w => w.PURCHASEID == id)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
