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
    }
}
