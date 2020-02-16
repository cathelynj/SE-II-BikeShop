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
    public class LetterStyleController : ApiController
    {
        public IHttpActionResult GetAllLetterStyle()
        {
            IList<LetterStyleViewModel> group = null;
            using (var ctx = new BikeShopEntities())
            {
                group = ctx.LETTERSTYLEs.Select(c => new LetterStyleViewModel()
                {
                   LetterStyle1 = c.LETTERSTYLE1,
                   Description = c.DESCRIPTION

                }).ToList<LetterStyleViewModel>();
            }
            if (group.Count == 0)
            {
                return NotFound();
            }

            return Ok(group);
        }
    //public IHttpActionResult PullLetterStyle(int id)
    //{
    //    LetterStyleViewModel group = null;

    //    using (var ctx = new BikeShopEntities())
    //    {
    //        group = ctx.LETTERSTYLEs
    //            .Where(e => e.LETTERSTYLE1 == id)
    //            .Select(e => new LetterStyleViewModel()
    //            {
    //                LetterStyle1 = e.LETTERSTYLE1,
    //                Description = e.DESCRIPTION
    //            }).FirstOrDefault<LetterStyleViewModel>();
    //    }
    //    if (group == null)
    //    {
    //        return NotFound();
    //    }
    //    return Ok(group);
    //}

    } 
}
