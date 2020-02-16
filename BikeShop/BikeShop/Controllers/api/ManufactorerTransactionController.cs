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
    }
}
