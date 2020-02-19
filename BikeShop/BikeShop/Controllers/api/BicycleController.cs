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

        public IHttpActionResult Put(BicycleViewModel b)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new BikeShopEntities())
            {
                var existingBike = ctx.BICYCLEs.Where(s => s.SERIALNUMBER == b.SERIALNUMBER).FirstOrDefault<BICYCLE>();
                if (existingBike != null)
                {
                    existingBike.SERIALNUMBER = b.SERIALNUMBER;
                    existingBike.CUSTOMERID = b.CUSTOMERID;
                    existingBike.MODELTYPE = b.MODELTYPE;
                    existingBike.PAINTID = b.PAINTID;
                    existingBike.FRAMESIZE = b.FRAMESIZE;
                    existingBike.ORDERDATE = b.ORDERDATE;
                    existingBike.STARTDATE = b.STARTDATE;
                    existingBike.SHIPDATE = b.SHIPDATE;
                    existingBike.SHIPEMPLOYEE = b.SHIPEMPLOYEE;
                    existingBike.FRAMEASSEMBLER = b.FRAMEASSEMBLER;
                    existingBike.PAINTER = b.PAINTER;
                    existingBike.CONSTRUCTION = b.CONSTRUCTION;
                    existingBike.WATERBOTTLEBRAZEONS = b.WATERBOTTLEBRAZEONS;
                    existingBike.CUSTOMNAME = b.CUSTOMNAME;
                    existingBike.LETTERSTYLEID = b.LETTERSTYLEID;
                    existingBike.STOREID = b.STOREID;
                    existingBike.EMPLOYEEID = b.EMPLOYEEID;
                    existingBike.TOPTUBE = b.TOPTUBE;
                    existingBike.CHAINSTAY = b.CHAINSTAY;
                    existingBike.HEADTUBEANGLE = b.HEADTUBEANGLE;
                    existingBike.SEATTUBEANGLE = b.SEATTUBEANGLE;
                    existingBike.LISTPRICE = b.LISTPRICE;
                    existingBike.SALEPRICE = b.SALEPRICE;
                    existingBike.SALESTAX = b.SALESTAX;
                    existingBike.SALESTATE = b.SALESTATE;
                    existingBike.SHIPPRICE = b.SHIPPRICE;
                    existingBike.FRAMEPRICE = b.FRAMEPRICE;
                    existingBike.COMPONENTLIST = b.COMPONENTLIST;

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
            if (id <= 0)
                return BadRequest("Not a valid manufactorer-transaction id");

            using (var ctx = new BikeShopEntities())
            {
                var bike = ctx.BICYCLEs
                    .Where(b => b.SERIALNUMBER == id)
                    .FirstOrDefault();

                ctx.Entry(bike).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
