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

        public IHttpActionResult GetPurchaseItem(int purchaseID, int componentID)
        {
            PurchaseItemViewModel pi = null;

            using (var ctx = new BikeShopEntities())
            {
                pi = ctx.PURCHASEITEMs
                    .Where(p => p.PURCHASEID == purchaseID && p.COMPONENTID == componentID)
                    .Select(p => new PurchaseItemViewModel()
                    {
                        PURCHASEID = p.PURCHASEID,
                        COMPONENTID = p.COMPONENTID,
                        PRICEPAID = p.PRICEPAID,
                        QUANTITY = p.QUANTITY,
                        QUANTITYRECEIVED = p.QUANTITYRECEIVED
                    }).FirstOrDefault<PurchaseItemViewModel>();
            }
            if (pi == null)
            {
                return NotFound();
            }
            return Ok(pi);
        }

        public IHttpActionResult PostNewPurchaseItem(PurchaseItemViewModel p)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.PURCHASEITEMs.Add(new PURCHASEITEM()
                {
                    PURCHASEID = p.PURCHASEID,
                    COMPONENTID = p.COMPONENTID,
                    PRICEPAID = p.PRICEPAID,
                    QUANTITY = p.QUANTITY,
                    QUANTITYRECEIVED = p.QUANTITYRECEIVED
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(PurchaseItemViewModel p)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.PURCHASEITEMs.Where(w => w.PURCHASEID == p.PURCHASEID && w.COMPONENTID == p.COMPONENTID).FirstOrDefault<PURCHASEITEM>();
                if (existingBP != null)
                {
                    existingBP.PURCHASEID = p.PURCHASEID;
                    existingBP.COMPONENTID = p.COMPONENTID;
                    existingBP.PRICEPAID = p.PRICEPAID;
                    existingBP.QUANTITY = p.QUANTITY;
                    existingBP.QUANTITYRECEIVED = p.QUANTITYRECEIVED;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        public IHttpActionResult Delete(int purchaseID, int componentID)
        {

            using (var ctx = new BikeShopEntities())
            {
                var bp = ctx.BIKEPARTS
                    .Where(w => w.SERIALNUMBER == purchaseID && w.COMPONENTID == componentID)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
