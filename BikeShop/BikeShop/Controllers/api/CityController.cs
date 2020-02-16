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
                    CityID = c.CITYID,
                    ZipCode = c.ZIPCODE,
                    CityName = c.CITY1,
                    State = c.STATE,
                    AreaCode = c.AREACODE,
                    Population1990 = c.POPULATION1990,
                    Population1980 = c.POPULATION1980,
                    Country = c.COUNTRY,
                    Latitude = c.LATITUDE,
                    Longitude = c.LONGITUDE,
                    PopulationCDF = c.POPULATIONCDF
                }).ToList<CityViewModel>();
            }
            if (cities.Count == 0)
            {
                return NotFound();
            }

            return Ok(cities);
        }

        public IHttpActionResult GetEmployee(int id)
        {
            CityViewModel city = null;

            using (var ctx = new BikeShopEntities())
            {
                city = ctx.CITies
                    .Where(c => c.CITYID == id)
                    .Select(c => new CityViewModel()
                    {
                        CityID = c.CITYID,
                        ZipCode = c.ZIPCODE,
                        CityName = c.CITY1,
                        State = c.STATE,
                        AreaCode = c.AREACODE,
                        Population1990 = c.POPULATION1990,
                        Population1980 = c.POPULATION1980,
                        Country = c.COUNTRY,
                        Latitude = c.LATITUDE,
                        Longitude = c.LONGITUDE,
                        PopulationCDF = c.POPULATIONCDF
                    }).FirstOrDefault<CityViewModel>();
            }
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        public IHttpActionResult PostNewEmployee(CityViewModel city)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.CITies.Add(new CITY()
                {
                    CITYID = city.CityID,
                    ZIPCODE = city.ZipCode,
                    CITY1 = city.CityName,
                    STATE = city.State,
                    AREACODE = city.AreaCode,
                    POPULATION1990 = city.Population1990,
                    POPULATION1980 = city.Population1980,
                    COUNTRY = city.Country,
                    LATITUDE = city.Latitude,
                    LONGITUDE = city.Longitude,
                    POPULATIONCDF = city.PopulationCDF
                });

                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
