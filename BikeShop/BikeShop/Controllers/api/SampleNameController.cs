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
    public class SampleNameController : ApiController
    {
        public IHttpActionResult GetAllSampleNames()
        {
            IList<SampleNameViewModel> samplename = null;
            using (var ctx = new BikeShopEntities())
            {
                samplename = ctx.SAMPLENAMEs.Select(s => new SampleNameViewModel()
                {
                   ID = s.ID,
                   FIRSTNAME = s.FIRSTNAME,
                   LASTNAME = s.LASTNAME,
                   GENDER = s.GENDER
                }).ToList<SampleNameViewModel>();
            }
            if (samplename.Count == 0)
            {
                return NotFound();
            }

            return Ok(samplename);
        }

        public IHttpActionResult GetSampleName(int id)
        {
            SampleNameViewModel sn = null;

            using (var ctx = new BikeShopEntities())
            {
                sn = ctx.SAMPLENAMEs
                    .Where(s => s.ID == id)
                    .Select(s => new SampleNameViewModel()
                    {
                        ID = s.ID,
                        FIRSTNAME = s.FIRSTNAME,
                        LASTNAME = s.LASTNAME,
                        GENDER = s.GENDER
                    }).FirstOrDefault<SampleNameViewModel>();
            }
            if (sn == null)
            {
                return NotFound();
            }
            return Ok(sn);
        }

        public IHttpActionResult PostNewSampleName(SampleNameViewModel s)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.SAMPLENAMEs.Add(new SAMPLENAME()
                {
                    ID = s.ID,
                    FIRSTNAME = s.FIRSTNAME,
                    LASTNAME = s.LASTNAME,
                    GENDER = s.GENDER
                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(SampleNameViewModel s)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBP = ctx.SAMPLENAMEs.Where(w => w.ID == s.ID).FirstOrDefault<SAMPLENAME>();
                if (existingBP != null)
                {
                    existingBP.ID = s.ID;
                    existingBP.FIRSTNAME = s.FIRSTNAME;
                    existingBP.LASTNAME = s.LASTNAME;
                    existingBP.GENDER = s.GENDER;

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
                var bp = ctx.SAMPLENAMEs
                    .Where(w => w.ID == id)
                    .FirstOrDefault();

                ctx.Entry(bp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
