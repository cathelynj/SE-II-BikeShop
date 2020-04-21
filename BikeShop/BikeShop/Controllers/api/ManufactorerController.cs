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
    public class ManufactorerController : ApiController
    {
        public IHttpActionResult GetAllManufactorers()
        {
            IList<ManufactorerViewModel> manufactorer = null;
            using (var ctx = new BikeShopEntities())
            {
                manufactorer = ctx.MANUFACTURERs.Select(m => new ManufactorerViewModel()
                {
                    MANUFACTURERID = m.MANUFACTURERID,
                    MANUFACTURERNAME = m.MANUFACTURERNAME,
                    CONTACTNAME = m.CONTACTNAME,
                    PHONE = m.PHONE,
                    ADDRESS = m.ADDRESS,
                    ZIPCODE = m.ZIPCODE,
                    CITYID = m.CITYID,
                    BALANCEDUE = m.BALANCEDUE
                }).ToList<ManufactorerViewModel>();
            }
            if (manufactorer.Count == 0)
            {
                return NotFound();
            }

            return Ok(manufactorer);
        }
    }
}
