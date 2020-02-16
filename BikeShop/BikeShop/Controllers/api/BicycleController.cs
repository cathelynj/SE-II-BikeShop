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
    public class BicycleController : ApiController
    {
        public IHttpActionResult GetAllBicycles()
        {
            IList<BicycleViewModel> bicycles = null;
            using (var ctx = new BikeShopEntities())
            {
                bicycles = ctx.BICYCLEs.Select(b => new BicycleViewModel()
                {
                    SERIALNUMBER = b.SERIALNUMBER,
                    CUSTOMERID = b.CUSTOMERID,
                    MODELTYPE = b.MODELTYPE,
                    PAINTID = b.PAINTID,
                    FRAMESIZE = b.FRAMESIZE,
                    ORDERDATE = b.ORDERDATE,
                    STARTDATE = b.STARTDATE,
                    SHIPDATE = b.SHIPDATE,
                    SHIPEMPLOYEE = b.SHIPEMPLOYEE,
                    FRAMEASSEMBLER = b.FRAMEASSEMBLER,
                    PAINTER = b.PAINTER,
                    CONSTRUCTION = b.CONSTRUCTION,
                    WATERBOTTLEBRAZEONS = b.WATERBOTTLEBRAZEONS,
                    CUSTOMNAME = b.CUSTOMNAME,
                    LETTERSTYLEID = b.LETTERSTYLEID,
                    STOREID = b.STOREID,
                    EMPLOYEEID = b.EMPLOYEEID,
                    TOPTUBE = b.TOPTUBE,
                    CHAINSTAY = b.CHAINSTAY,
                    HEADTUBEANGLE = b.HEADTUBEANGLE,
                    SEATTUBEANGLE = b.SEATTUBEANGLE,
                    LISTPRICE = b.LISTPRICE,
                    SALEPRICE = b.SALEPRICE,
                    SALESTAX = b.SALESTAX,
                    SALESTATE = b.SALESTATE,
                    SHIPPRICE = b.SHIPPRICE,
                    FRAMEPRICE = b.FRAMEPRICE,
                    COMPONENTLIST = b.COMPONENTLIST
                }).ToList<BicycleViewModel>();
            }
            if (bicycles.Count == 0)
            {
                return NotFound();
            }

            return Ok(bicycles);
        }

        public IHttpActionResult GetBicycle(int id)
        {
            BicycleViewModel bicycle = null;

            using (var ctx = new BikeShopEntities())
            {
                bicycle = ctx.BICYCLEs
                    .Where(b => b.SERIALNUMBER == id)
                    .Select(b => new BicycleViewModel()
                    {
                        SERIALNUMBER = b.SERIALNUMBER,
                        CUSTOMERID = b.CUSTOMERID,
                        MODELTYPE = b.MODELTYPE,
                        PAINTID = b.PAINTID,
                        FRAMESIZE = b.FRAMESIZE,
                        ORDERDATE = b.ORDERDATE,
                        STARTDATE = b.STARTDATE,
                        SHIPDATE = b.SHIPDATE,
                        SHIPEMPLOYEE = b.SHIPEMPLOYEE,
                        FRAMEASSEMBLER = b.FRAMEASSEMBLER,
                        PAINTER = b.PAINTER,
                        CONSTRUCTION = b.CONSTRUCTION,
                        WATERBOTTLEBRAZEONS = b.WATERBOTTLEBRAZEONS,
                        CUSTOMNAME = b.CUSTOMNAME,
                        LETTERSTYLEID = b.LETTERSTYLEID,
                        STOREID = b.STOREID,
                        EMPLOYEEID = b.EMPLOYEEID,
                        TOPTUBE = b.TOPTUBE,
                        CHAINSTAY = b.CHAINSTAY,
                        HEADTUBEANGLE = b.HEADTUBEANGLE,
                        SEATTUBEANGLE = b.SEATTUBEANGLE,
                        LISTPRICE = b.LISTPRICE,
                        SALEPRICE = b.SALEPRICE,
                        SALESTAX = b.SALESTAX,
                        SALESTATE = b.SALESTATE,
                        SHIPPRICE = b.SHIPPRICE,
                        FRAMEPRICE = b.FRAMEPRICE,
                        COMPONENTLIST = b.COMPONENTLIST
                    }).FirstOrDefault<BicycleViewModel>();
            }
            if (bicycle == null)
            {
                return NotFound();
            }
            return Ok(bicycle);
        }

        public IHttpActionResult PostNewBicycle(BicycleViewModel b)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.BICYCLEs.Add(new BICYCLE()
                {
                    SERIALNUMBER = b.SERIALNUMBER,
                    CUSTOMERID = b.CUSTOMERID,
                    MODELTYPE = b.MODELTYPE,
                    PAINTID = b.PAINTID,
                    FRAMESIZE = b.FRAMESIZE,
                    ORDERDATE = b.ORDERDATE,
                    STARTDATE = b.STARTDATE,
                    SHIPDATE = b.SHIPDATE,
                    SHIPEMPLOYEE = b.SHIPEMPLOYEE,
                    FRAMEASSEMBLER = b.FRAMEASSEMBLER,
                    PAINTER = b.PAINTER,
                    CONSTRUCTION = b.CONSTRUCTION,
                    WATERBOTTLEBRAZEONS = b.WATERBOTTLEBRAZEONS,
                    CUSTOMNAME = b.CUSTOMNAME,
                    LETTERSTYLEID = b.LETTERSTYLEID,
                    STOREID = b.STOREID,
                    EMPLOYEEID = b.EMPLOYEEID,
                    TOPTUBE = b.TOPTUBE,
                    CHAINSTAY = b.CHAINSTAY,
                    HEADTUBEANGLE = b.HEADTUBEANGLE,
                    SEATTUBEANGLE = b.SEATTUBEANGLE,
                    LISTPRICE = b.LISTPRICE,
                    SALEPRICE = b.SALEPRICE,
                    SALESTAX = b.SALESTAX,
                    SALESTATE = b.SALESTATE,
                    SHIPPRICE = b.SHIPPRICE,
                    FRAMEPRICE = b.FRAMEPRICE,
                    COMPONENTLIST = b.COMPONENTLIST
                });

                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
