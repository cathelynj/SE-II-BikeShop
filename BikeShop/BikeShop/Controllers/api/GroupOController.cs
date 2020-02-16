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
    public class GroupOController : ApiController
    {
        public IHttpActionResult GetAllGroupO()
        {
            IList<GroupOViewModel> group = null;
            using (var ctx = new BikeShopEntities())
            {
                group = ctx.GROUPOes.Select(c => new GroupOViewModel()
                {
                    ComponentGroupID = c.COMPONENTGROUPID,
                    GroupName = c.GROUPNAME,
                    BikeType = c.BIKETYPE,
                    Year = c.YEAR,
                    EndYear = c.ENDYEAR,
                    Weight = c.WEIGHT

                }).ToList<GroupOViewModel>();
            }
            if (group.Count == 0)
            {
                return NotFound();
            }

            return Ok(group);
        }
       

        public IHttpActionResult GetGroupO(int id)
        {
            GroupOViewModel group = null;

            using (var ctx = new BikeShopEntities())
            {
                group = ctx.GROUPOes
                    .Where(e => e.COMPONENTGROUPID == id)
                    .Select(e => new GroupOViewModel()
                    {
                        ComponentGroupID = e.COMPONENTGROUPID,
                        GroupName = e.GROUPNAME,
                        BikeType = e.BIKETYPE,
                        Year = e.YEAR,
                        EndYear = e.ENDYEAR,
                        Weight = e.WEIGHT
                    }).FirstOrDefault<GroupOViewModel>();
            }
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }
    }
}

