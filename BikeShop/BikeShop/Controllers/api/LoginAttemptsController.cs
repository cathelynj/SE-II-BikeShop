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
    public class LoginAttemptsController : ApiController
    {
        public IHttpActionResult GetAllLoginAttempts()
        {
            IList<LoginAttempts> loginAttempts = null;
            using (var ctx = new SE2MetricEntities())
            {
                loginAttempts = ctx.LoginAttempts.Select(t => new LoginAttempts()
                {
                    Id = t.Id,
                    UserName = t.UserName,
                    Successful = (bool)t.Successful
                }).ToList<LoginAttempts>();
            }
            if (loginAttempts.Count == 0)
            {
                return NotFound();
            }

            return Ok(loginAttempts);
        }

        public IHttpActionResult PostLoginAttempts(LoginAttempts la)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new SE2MetricEntities())
            {
                ctx.LoginAttempts.Add(new LoginAttempt()
                {
                    Id = la.Id,
                    UserName = la.UserName,
                    Successful = la.Successful
                });

                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
