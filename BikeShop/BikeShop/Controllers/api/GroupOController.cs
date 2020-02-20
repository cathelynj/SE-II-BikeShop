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

        public IHttpActionResult PostNewGroupO(GroupOViewModel c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.GROUPOes.Add(new GROUPO()
                {
                    COMPONENTGROUPID = c.ComponentGroupID,
                    GROUPNAME = c.GroupName,
                    BIKETYPE = c.BikeType,
                    YEAR = c.Year,
                    ENDYEAR = c.EndYear,
                    WEIGHT = c.Weight
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(GroupOViewModel c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.GROUPOes.Where(w => w.COMPONENTGROUPID == c.ComponentGroupID).FirstOrDefault<GROUPO>();
                if (existingBP != null)
                {
                    existingBP.COMPONENTGROUPID = c.ComponentGroupID;
                    existingBP.GROUPNAME = c.GroupName;
                    existingBP.BIKETYPE = c.BikeType;
                    existingBP.YEAR = c.Year;
                    existingBP.ENDYEAR = c.EndYear;
                    existingBP.WEIGHT = c.Weight;

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
                var bp = ctx.GROUPOes
                    .Where(w => w.COMPONENTGROUPID == id)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}

