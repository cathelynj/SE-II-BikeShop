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
    public class CustomerController : ApiController
    {
        public IHttpActionResult GetAllCustomers()
        {
            IList<CustomerViewModel> customer = null;
            using (var ctx = new BikeShopEntities())
            {
                customer = ctx.CUSTOMERs.Select(c => new CustomerViewModel()
                {
                    CUSTOMERID = c.CUSTOMERID,
                    PHONE = c.PHONE,
                    FIRSTNAME = c.FIRSTNAME,
                    LASTNAME = c.LASTNAME,
                    ADDRESS = c.ADDRESS,
                    ZIPCODE = c.ZIPCODE,
                    CITYID = c.CITYID,
                    BALANCEDUE = c.BALANCEDUE
                }).ToList<CustomerViewModel>();
            }
            if (customer.Count == 0)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            CustomerViewModel customer = null;

            using (var ctx = new BikeShopEntities())
            {
                customer = ctx.CUSTOMERs
                    .Where(c => c.CUSTOMERID == id)
                    .Select(c => new CustomerViewModel()
                    {
                        CUSTOMERID = c.CUSTOMERID,
                        PHONE = c.PHONE,
                        FIRSTNAME = c.FIRSTNAME,
                        LASTNAME = c.LASTNAME,
                        ADDRESS = c.ADDRESS,
                        ZIPCODE = c.ZIPCODE,
                        CITYID = c.CITYID,
                        BALANCEDUE = c.BALANCEDUE
                    }).FirstOrDefault<CustomerViewModel>();
            }
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        public IHttpActionResult PostNewCustomer(CustomerViewModel c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.CUSTOMERs.Add(new CUSTOMER()
                {
                    CUSTOMERID = c.CUSTOMERID,
                    PHONE = c.PHONE,
                    FIRSTNAME = c.FIRSTNAME,
                    LASTNAME = c.LASTNAME,
                    ADDRESS = c.ADDRESS,
                    ZIPCODE = c.ZIPCODE,
                    CITYID = c.CITYID,
                    BALANCEDUE = c.BALANCEDUE
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(CustomerViewModel c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingC = ctx.CUSTOMERs.Where(w => w.CUSTOMERID == c.CUSTOMERID).FirstOrDefault<CUSTOMER>();
                if (existingC != null)
                {
                    existingC.CUSTOMERID = c.CUSTOMERID;
                    existingC.PHONE = c.PHONE;
                    existingC.FIRSTNAME = c.FIRSTNAME;
                    existingC.LASTNAME = c.LASTNAME;
                    existingC.ADDRESS = c.ADDRESS;
                    existingC.ZIPCODE = c.ZIPCODE;
                    existingC.CITYID = c.CITYID;
                    existingC.BALANCEDUE = c.BALANCEDUE;

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
                var bp = ctx.CUSTOMERs
                    .Where(w => w.CUSTOMERID == id)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
