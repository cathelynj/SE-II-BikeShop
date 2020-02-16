using BikeShop.Models;
using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BikeShop.Controllers
{
    public class CustomerController : ApiController
    {
        public IHttpActionResult GetAllCustomers()
        {
            IList<CustomerViewModel> customers = null;
            using (var ctx = new BikeShopEntities())
            {
                customers = ctx.CUSTOMERs.Select(c => new CustomerViewModel()
                {
                     CustomerID = c.CUSTOMERID,
                     Phone = c.PHONE,
                     FirstName = c.FIRSTNAME,
                     LastName = c.LASTNAME,
                     Address = c.ADDRESS,
                     Zipcode = c.ZIPCODE,
                     CityID = c.CITYID,
                     BalanceDue = c.BALANCEDUE
    }).ToList<CustomerViewModel>();
            }
            if (customers.Count == 0)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        public IHttpActionResult GetEmployee(int id)
        {
            CustomerViewModel customer = null;

            using (var ctx = new BikeShopEntities())
            {
                customer = ctx.CUSTOMERs
                    .Where(e => e.CUSTOMERID == id)
                    .Select(e => new CustomerViewModel()
                    {
                        CustomerID = e.CUSTOMERID,
                        Phone = e.PHONE,
                        FirstName = e.FIRSTNAME,
                        LastName = e.LASTNAME,
                        Address = e.ADDRESS,
                        Zipcode = e.ZIPCODE,
                        CityID = e.CITYID,
                        BalanceDue = e.BALANCEDUE
                    }).FirstOrDefault<CustomerViewModel>();
            }
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}
