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
    public class CityController : ApiController
    {
        public IHttpActionResult GetAllCities()
        {
            IList<CityViewModel> cities = null;
            using (var ctx = new BikeShopEntities())
            {
                cities = ctx.CITies.Select(c => new CityViewModel()
                {
                    CITYID = c.CITYID,
                    ZIPCODE = c.ZIPCODE,
                    CITY1 = c.CITY1,
                    STATE = c.STATE,
                    AREACODE = c.AREACODE,
                    POPULATION1990 = c.POPULATION1990,
                    POPULATION1980 = c.POPULATION1980,
                    COUNTRY = c.COUNTRY,
                    LATITUDE = c.LATITUDE,
                    LONGITUDE = c.LONGITUDE,
                    POPULATIONCDF = c.POPULATIONCDF
                }).ToList<CityViewModel>();
            }
            if (cities.Count == 0)
            {
                return NotFound();
            }

            return Ok(cities);
        }

        public IHttpActionResult GetCity(int id)
        {
            CityViewModel city = null;

            using (var ctx = new BikeShopEntities())
            {
                city = ctx.CITies
                    .Where(c => c.CITYID == id)
                    .Select(c => new CityViewModel()
                    {
                        CITYID = c.CITYID,
                        ZIPCODE = c.ZIPCODE,
                        CITY1 = c.CITY1,
                        STATE = c.STATE,
                        AREACODE = c.AREACODE,
                        POPULATION1990 = c.POPULATION1990,
                        POPULATION1980 = c.POPULATION1980,
                        COUNTRY = c.COUNTRY,
                        LATITUDE = c.LATITUDE,
                        LONGITUDE = c.LONGITUDE,
                        POPULATIONCDF = c.POPULATIONCDF
                    }).FirstOrDefault<CityViewModel>();
            }
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        public IHttpActionResult PostNewCity(CityViewModel c)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.CITies.Add(new CITY()
                {
                    CITYID = c.CITYID,
                    ZIPCODE = c.ZIPCODE,
                    CITY1 = c.CITY1,
                    STATE = c.STATE,
                    AREACODE = c.AREACODE,
                    POPULATION1990 = c.POPULATION1990,
                    POPULATION1980 = c.POPULATION1980,
                    COUNTRY = c.COUNTRY,
                    LATITUDE = c.LATITUDE,
                    LONGITUDE = c.LONGITUDE,
                    POPULATIONCDF = c.POPULATIONCDF
                });

                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
