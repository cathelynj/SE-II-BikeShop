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
    public class ManufactorerTransactionController : ApiController
    {
        public IHttpActionResult GetAllManufactorerTransactions()
        {
            IList<ManufactorerTransactionViewModel> manufactorertransactions = null;
            using (var ctx = new BikeShopEntities())
            {
                manufactorertransactions = ctx.MANUFACTURERTRANSACTIONs.Select(m => new ManufactorerTransactionViewModel()
                {
                    MANUFACTURERID = m.MANUFACTURERID,
                    TRANSACTIONDATE = m.TRANSACTIONDATE,
                    EMPLOYEEID = m.EMPLOYEEID,
                    AMOUNT = m.AMOUNT,
                    DESCRIPTION = m.DESCRIPTION,
                    REFERENCE = m.REFERENCE
                }).ToList<ManufactorerTransactionViewModel>();
            }
            if (manufactorertransactions.Count == 0)
            {
                return NotFound();
            }

            return Ok(manufactorertransactions);
        }

        public IHttpActionResult GetOneManufactorerTransaction(int id, System.DateTime date, int reference)
        {
            ManufactorerTransactionViewModel manufactorerTransaction = null;
            using (var ctx = new BikeShopEntities())
            {
                manufactorerTransaction = ctx.MANUFACTURERTRANSACTIONs
                                            .Where(mt => mt.MANUFACTURERID == id && mt.TRANSACTIONDATE == date && mt.REFERENCE == reference)
                                            .Select(mt => new ManufactorerTransactionViewModel()
                                            {
                                                MANUFACTURERID = mt.MANUFACTURERID,
                                                TRANSACTIONDATE = mt.TRANSACTIONDATE,
                                                EMPLOYEEID = mt.EMPLOYEEID,
                                                AMOUNT = mt.AMOUNT,
                                                DESCRIPTION = mt.DESCRIPTION,
                                                REFERENCE = mt.REFERENCE
                                            }).FirstOrDefault<ManufactorerTransactionViewModel>();
                if (manufactorerTransaction == null)
                    return NotFound();
                return Ok(manufactorerTransaction);
            }
        }

        public IHttpActionResult PostNewManufacturerTransaction(ManufactorerTransactionViewModel mt)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.MANUFACTURERTRANSACTIONs.Add(new MANUFACTURERTRANSACTION()
                {
                    MANUFACTURERID = mt.MANUFACTURERID,
                    TRANSACTIONDATE = mt.TRANSACTIONDATE,
                    EMPLOYEEID = mt.EMPLOYEEID,
                    AMOUNT = mt.AMOUNT,
                    DESCRIPTION = mt.DESCRIPTION,
                    REFERENCE = mt.REFERENCE
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(ManufactorerTransactionViewModel mt)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingMT = ctx.MANUFACTURERTRANSACTIONs.Where(s => s.MANUFACTURERID == mt.MANUFACTURERID && s.TRANSACTIONDATE == mt.TRANSACTIONDATE && s.REFERENCE == mt.REFERENCE).FirstOrDefault<MANUFACTURERTRANSACTION>();
                if (existingMT != null)
                {
                    existingMT.MANUFACTURERID = mt.MANUFACTURERID;
                    existingMT.TRANSACTIONDATE = mt.TRANSACTIONDATE;
                    existingMT.EMPLOYEEID = mt.EMPLOYEEID;
                    existingMT.AMOUNT = mt.AMOUNT;
                    existingMT.DESCRIPTION = mt.DESCRIPTION;
                    existingMT.REFERENCE = mt.REFERENCE;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id, System.DateTime date, int reference)
        {
            if (id <= 0)
                return BadRequest("Not a valid manufactorer-transaction id");

            using (var ctx = new BikeShopEntities())
            {
                var mt = ctx.MANUFACTURERTRANSACTIONs
                    .Where(c => c.MANUFACTURERID == id && c.TRANSACTIONDATE == date && c.REFERENCE == reference)
                    .FirstOrDefault();

                ctx.Entry(mt).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
