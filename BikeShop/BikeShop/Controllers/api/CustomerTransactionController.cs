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
    public class CustomerTransactionController : ApiController
    {
        public IHttpActionResult GetAllCustomerTransactions()
        {
            IList<CustomerTransactionViewModel> customertransaction = null;
            using (var ctx = new BikeShopEntities())
            {
                customertransaction = ctx.CUSTOMERTRANSACTIONs.Select(c => new CustomerTransactionViewModel()
                {
                    CUSTOMERID = c.CUSTOMERID,
                    TRANSACTIONDATE = c.TRANSACTIONDATE,
                    EMPLOYEEID = c.EMPLOYEEID,
                    AMOUNT = c.AMOUNT,
                    DESCRIPTION = c.DESCRIPTION,
                    REFERENCE = c.REFERENCE
                }).ToList<CustomerTransactionViewModel>();
            }
            if (customertransaction.Count == 0)
            {
                return NotFound();
            }

            return Ok(customertransaction);
        }

        public IHttpActionResult GetCustomerTransaction(int id, System.DateTime date)
        {
            CustomerTransactionViewModel ct = null;

            using (var ctx = new BikeShopEntities())
            {
                ct = ctx.CUSTOMERTRANSACTIONs
                    .Where(c => c.CUSTOMERID == id && c.TRANSACTIONDATE == date)
                    .Select(c => new CustomerTransactionViewModel()
                    {
                        CUSTOMERID = c.CUSTOMERID,
                        TRANSACTIONDATE = c.TRANSACTIONDATE,
                        EMPLOYEEID = c.EMPLOYEEID,
                        AMOUNT = c.AMOUNT,
                        DESCRIPTION = c.DESCRIPTION,
                        REFERENCE = c.REFERENCE
                    }).FirstOrDefault<CustomerTransactionViewModel>();
            }
            if (ct == null)
            {
                return NotFound();
            }
            return Ok(ct);
        }

        public IHttpActionResult PostNewBikePart(CustomerTransactionViewModel c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.CUSTOMERTRANSACTIONs.Add(new CUSTOMERTRANSACTION()
                {
                    CUSTOMERID = c.CUSTOMERID,
                    TRANSACTIONDATE = c.TRANSACTIONDATE,
                    EMPLOYEEID = c.EMPLOYEEID,
                    AMOUNT = c.AMOUNT,
                    DESCRIPTION = c.DESCRIPTION,
                    REFERENCE = c.REFERENCE
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(CustomerTransactionViewModel c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingCT = ctx.CUSTOMERTRANSACTIONs.Where(w => w.CUSTOMERID == c.CUSTOMERID && w.TRANSACTIONDATE == c.TRANSACTIONDATE).FirstOrDefault<CUSTOMERTRANSACTION>();
                if (existingCT != null)
                {
                    existingCT.CUSTOMERID = c.CUSTOMERID;
                    existingCT.TRANSACTIONDATE = c.TRANSACTIONDATE;
                    existingCT.EMPLOYEEID = c.EMPLOYEEID;
                    existingCT.AMOUNT = c.AMOUNT;
                    existingCT.DESCRIPTION = c.DESCRIPTION;
                    existingCT.REFERENCE = c.REFERENCE;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id, System.DateTime date)
        {

            using (var ctx = new BikeShopEntities())
            {
                var bp = ctx.CUSTOMERTRANSACTIONs
                    .Where(w => w.CUSTOMERID == id && w.TRANSACTIONDATE == date)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
