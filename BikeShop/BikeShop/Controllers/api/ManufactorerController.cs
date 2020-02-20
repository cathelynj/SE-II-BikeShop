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
    public class ManufactorerController : ApiController
    {
        public IHttpActionResult GetAllManufactorers()
        {
            IList<ManufactorerViewModel> manufactorer = null;
            using (var ctx = new BikeShopEntities())
            {
                manufactorer = ctx.MANUFACTURERs.Select(m => new ManufactorerViewModel()
                {
                    MANUFACTURERID = m.MANUFACTURERID,
                    MANUFACTURERNAME = m.MANUFACTURERNAME,
                    CONTACTNAME = m.CONTACTNAME,
                    PHONE = m.PHONE,
                    ADDRESS = m.ADDRESS,
                    ZIPCODE = m.ZIPCODE,
                    CITYID = m.CITYID,
                    BALANCEDUE = m.BALANCEDUE
                }).ToList<ManufactorerViewModel>();
            }
            if (manufactorer.Count == 0)
            {
                return NotFound();
            }

            return Ok(manufactorer);
        }

        public IHttpActionResult GetBikePart(int id)
        {
            ManufactorerViewModel man = null;

            using (var ctx = new BikeShopEntities())
            {
                man = ctx.MANUFACTURERs
                    .Where(m => m.MANUFACTURERID == id)
                    .Select(m => new ManufactorerViewModel()
                    {
                        MANUFACTURERID = m.MANUFACTURERID,
                        MANUFACTURERNAME = m.MANUFACTURERNAME,
                        CONTACTNAME = m.CONTACTNAME,
                        PHONE = m.PHONE,
                        ADDRESS = m.ADDRESS,
                        ZIPCODE = m.ZIPCODE,
                        CITYID = m.CITYID,
                        BALANCEDUE = m.BALANCEDUE
                    }).FirstOrDefault<ManufactorerViewModel>();
            }
            if (man == null)
            {
                return NotFound();
            }
            return Ok(man);
        }

        public IHttpActionResult PostNewBikePart(ManufactorerViewModel m)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.MANUFACTURERs.Add(new MANUFACTURER()
                {
                    MANUFACTURERID = m.MANUFACTURERID,
                    MANUFACTURERNAME = m.MANUFACTURERNAME,
                    CONTACTNAME = m.CONTACTNAME,
                    PHONE = m.PHONE,
                    ADDRESS = m.ADDRESS,
                    ZIPCODE = m.ZIPCODE,
                    CITYID = m.CITYID,
                    BALANCEDUE = m.BALANCEDUE
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(ManufactorerViewModel m)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.MANUFACTURERs.Where(w => w.MANUFACTURERID == m.MANUFACTURERID).FirstOrDefault<MANUFACTURER>();
                if (existingBP != null)
                {
                    existingBP.MANUFACTURERID = m.MANUFACTURERID;
                    existingBP.MANUFACTURERNAME = m.MANUFACTURERNAME;
                    existingBP.CONTACTNAME = m.CONTACTNAME;
                    existingBP.PHONE = m.PHONE;
                    existingBP.ADDRESS = m.ADDRESS;
                    existingBP.ZIPCODE = m.ZIPCODE;
                    existingBP.CITYID = m.CITYID;
                    existingBP.BALANCEDUE = m.BALANCEDUE;

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
                var bp = ctx.MANUFACTURERs
                    .Where(w => w.MANUFACTURERID == id)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
