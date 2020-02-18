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
    public class PreferenceController : ApiController
    {
        public class GroupOController : ApiController
        {
            public IHttpActionResult GetAllGroupO()
            {
                IList<PreferenceViewModel> preference = null;
                using (var ctx = new BikeShopEntities())
                {
                    preference = ctx.PREFERENCEs.Select(c => new PreferenceViewModel()
                    {
                        ItemName = c.ITEMNAME,
                        Value = c.VALUE,
                        Description = c.DESCRIPTION,
                        DateChanged = c.DATECHANGED

                    }).ToList<PreferenceViewModel>();
                }
                if (preference.Count == 0)
                {
                    return NotFound();
                }

                return Ok(preference);
            }
        }
    }
}