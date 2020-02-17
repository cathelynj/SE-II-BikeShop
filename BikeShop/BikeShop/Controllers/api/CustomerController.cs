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
    }
}
