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

        public IHttpActionResult GetRetailStore(int id)
        {
            RetailStoreViewModel retail = null;

            using (var ctx = new BikeShopEntities())
            {
                retail = ctx.RETAILSTOREs
                    .Where(r => r.STOREID == id)
                    .Select(r => new RetailStoreViewModel()
                    {
                        STOREID = r.STOREID,
                        STORENAME = r.STORENAME,
                        PHONE = r.PHONE,
                        CONTACTFIRSTNAME = r.CONTACTFIRSTNAME,
                        CONTACTLASTNAME = r.CONTACTLASTNAME,
                        ADDRESS = r.ADDRESS,
                        ZIPCODE = r.ZIPCODE,
                        CITYID = r.CITYID
                    }).FirstOrDefault<RetailStoreViewModel>();
            }
            if (retail == null)
            {
                return NotFound();
            }
            return Ok(retail);
        }

        public IHttpActionResult PostNewRetailStore(RetailStoreViewModel r)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.RETAILSTOREs.Add(new RETAILSTORE()
                {
                    STOREID = r.STOREID,
                    STORENAME = r.STORENAME,
                    PHONE = r.PHONE,
                    CONTACTFIRSTNAME = r.CONTACTFIRSTNAME,
                    CONTACTLASTNAME = r.CONTACTLASTNAME,
                    ADDRESS = r.ADDRESS,
                    ZIPCODE = r.ZIPCODE,
                    CITYID = r.CITYID
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(RetailStoreViewModel r)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.RETAILSTOREs.Where(w => w.STOREID == r.STOREID).FirstOrDefault<RETAILSTORE>();
                if (existingBP != null)
                {
                    existingBP.STOREID = r.STOREID;
                    existingBP.STORENAME = r.STORENAME;
                    existingBP.PHONE = r.PHONE;
                    existingBP.CONTACTFIRSTNAME = r.CONTACTFIRSTNAME;
                    existingBP.CONTACTLASTNAME = r.CONTACTLASTNAME;
                    existingBP.ADDRESS = r.ADDRESS;
                    existingBP.ZIPCODE = r.ZIPCODE;
                    existingBP.CITYID = r.CITYID;

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
                var bp = ctx.RETAILSTOREs
                    .Where(w => w.STOREID == id)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
