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
                    SerialNumber = b.SERIALNUMBER,
                    CustomerID = b.CUSTOMERID,
                    ModelType = b.MODELTYPE,
                    PaintID = b.PAINTID,
                    FrameSize = b.FRAMESIZE,
                    OrderDate = b.ORDERDATE,
                    StartDate = b.STARTDATE,
                    ShipDate = b.SHIPDATE,
                    ShipEmployee = b.SHIPEMPLOYEE,
                    FrameAssembler = b.FRAMEASSEMBLER,
                    Painter = b.PAINTER,
                    Construction = b.CONSTRUCTION,
                    WaterBottleBrazeOns = b.WATERBOTTLEBRAZEONS,
                    CustomName = b.CUSTOMNAME,
                    LetterstyleID = b.LETTERSTYLEID,
                    StoreID = b.STOREID,
                    EmployeeID = b.EMPLOYEEID,
                    TopTube = b.TOPTUBE,
                    ChainStay = b.CHAINSTAY,
                    HeadTubeAngle = b.HEADTUBEANGLE,
                    SeaTubeAngle = b.SEATTUBEANGLE,
                    ListPrice = b.LISTPRICE,
                    SalePrice = b.SALEPRICE,
                    SalesTax = b.SALESTAX,
                    SalesState = b.SALESTATE,
                    ShipPrice = b.SHIPPRICE,
                    FramePrice = b.FRAMEPRICE,
                    ComponentList = b.COMPONENTLIST                    
                }).ToList<BicycleViewModel>();
            }
            if (bicycles.Count == 0)
            {
                return NotFound();
            }

            return Ok(bicycles);
        }

        public IHttpActionResult GetEmployee(int id)
        {
            BicycleViewModel bicycle = null;

            using (var ctx = new BikeShopEntities())
            {
                bicycle = ctx.BICYCLEs
                    .Where(b => b.SERIALNUMBER == id)
                    .Select(b => new BicycleViewModel()
                    {
                        SerialNumber = b.SERIALNUMBER,
                        CustomerID = b.CUSTOMERID,
                        ModelType = b.MODELTYPE,
                        PaintID = b.PAINTID,
                        FrameSize = b.FRAMESIZE,
                        OrderDate = b.ORDERDATE,
                        StartDate = b.STARTDATE,
                        ShipDate = b.SHIPDATE,
                        ShipEmployee = b.SHIPEMPLOYEE,
                        FrameAssembler = b.FRAMEASSEMBLER,
                        Painter = b.PAINTER,
                        Construction = b.CONSTRUCTION,
                        WaterBottleBrazeOns = b.WATERBOTTLEBRAZEONS,
                        CustomName = b.CUSTOMNAME,
                        LetterstyleID = b.LETTERSTYLEID,
                        StoreID = b.STOREID,
                        EmployeeID = b.EMPLOYEEID,
                        TopTube = b.TOPTUBE,
                        ChainStay = b.CHAINSTAY,
                        HeadTubeAngle = b.HEADTUBEANGLE,
                        SeaTubeAngle = b.SEATTUBEANGLE,
                        ListPrice = b.LISTPRICE,
                        SalePrice = b.SALEPRICE,
                        SalesTax = b.SALESTAX,
                        SalesState = b.SALESTATE,
                        ShipPrice = b.SHIPPRICE,
                        FramePrice = b.FRAMEPRICE,
                        ComponentList = b.COMPONENTLIST
                    }).FirstOrDefault<BicycleViewModel>();
            }
            if (bicycle == null)
            {
                return NotFound();
            }
            return Ok(bicycle);
        }

        public IHttpActionResult PostNewEmployee(BicycleViewModel bike)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.BICYCLEs.Add(new BICYCLE()
                {
                    SERIALNUMBER = bike.SerialNumber,
                    CUSTOMERID = bike.CustomerID,
                    MODELTYPE = bike.ModelType,
                    PAINTID = bike.PaintID,
                    FRAMESIZE = bike.FrameSize,
                    ORDERDATE = bike.OrderDate,
                    STARTDATE = bike.StartDate,
                    SHIPDATE = bike.ShipDate,
                    SHIPEMPLOYEE = bike.ShipEmployee,
                    FRAMEASSEMBLER = bike.FrameAssembler,
                    PAINTER = bike.Painter,
                    CONSTRUCTION = bike.Construction,
                    WATERBOTTLEBRAZEONS = bike.WaterBottleBrazeOns,
                    CUSTOMNAME = bike.CustomName,
                    LETTERSTYLEID = bike.LetterstyleID,
                    STOREID = bike.StoreID,
                    EMPLOYEEID = bike.EmployeeID,
                    TOPTUBE = bike.TopTube,
                    CHAINSTAY = bike.ChainStay,
                    HEADTUBEANGLE = bike.HeadTubeAngle,
                    SEATTUBEANGLE = bike.SeaTubeAngle,
                    LISTPRICE = bike.ListPrice,
                    SALEPRICE = bike.SalePrice,
                    SALESTAX = bike.SalesTax,
                    SALESTATE = bike.SalesState,
                    SHIPPRICE = bike.ShipPrice,
                    FRAMEPRICE = bike.FramePrice,
                    COMPONENTLIST = bike.ComponentList
                });

                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
