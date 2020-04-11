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
    public class TransactionsController : ApiController
    {
        public IHttpActionResult GetAllTransaction()
        {
            IList<Transactions> transactions = null;
            using (var ctx = new SE2MetricEntities())
            {
                transactions = ctx.Transactions.Select(t => new Transactions()
                {
                    Id = t.Id,
                    Quantity = (int)t.Quantity
                }).ToList<Transactions>();
            }
            if (transactions.Count == 0)
            {
                return NotFound();
            }

            return Ok(transactions);
        }

        public IHttpActionResult PostTransaction(Transactions t)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new SE2MetricEntities())
            {
                ctx.Transactions.Add(new Transaction()
                {
                    Id = t.Id,
                    Quantity = t.Quantity
                });

                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
