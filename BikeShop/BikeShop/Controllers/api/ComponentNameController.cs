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
    public class ComponentNameController : ApiController
    {
        public IHttpActionResult GetAllComponentNames()
        {
            IList<ComponentNameViewModel> componentname = null;
            using (var ctx = new BikeShopEntities())
            {
                componentname = ctx.COMPONENTNAMEs.Select(c => new ComponentNameViewModel()
                {
                    COMPONENTNAME1 = c.COMPONENTNAME1,
                    ASSEMBLYORDER = c.ASSEMBLYORDER,
                    DESCRIPTION = c.DESCRIPTION
                }).ToList<ComponentNameViewModel>();
            }
            if (componentname.Count == 0)
            {
                return NotFound();
            }

            return Ok(componentname);
        }
    }
}
