using BikeShop.Models;
using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BikeShop.Controllers
{
    public class EmployeeController : ApiController
    {
        public IHttpActionResult GetAllEmployees()
        {
            IList<EmployeeViewModel> employees = null;
            using (var ctx = new BikeShopEntities())
            {
                employees = ctx.EMPLOYEEs.Select(e => new EmployeeViewModel()
                {
                    EMPLOYEEID = e.EMPLOYEEID,
                    TAXPAYERID = e.TAXPAYERID,
                    LASTNAME = e.LASTNAME,
                    FIRSTNAME = e.FIRSTNAME,
                    HOMEPHONE = e.HOMEPHONE,
                    ADDRESS = e.ADDRESS,
                    ZIPCODE = e.ZIPCODE,
                    CITYID = e.CITYID,
                    DATEHIRED = e.DATEHIRED,
                    DATERELEASED = e.DATERELEASED,
                    CURRENTMANAGER = e.CURRENTMANAGER,
                    SALARYGRADE = e.SALARYGRADE,
                    SALARY = e.SALARY,
                    TITLE = e.TITLE,
                    WORKAREA = e.WORKAREA
                }).ToList<EmployeeViewModel>();
            }
            if (employees.Count == 0)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        public IHttpActionResult GetEmployee(int id)
        {
            EmployeeViewModel employee = null;

            using (var ctx = new BikeShopEntities())
            {
                employee = ctx.EMPLOYEEs
                    .Where(e => e.EMPLOYEEID == id)
                    .Select(e => new EmployeeViewModel()
                    {
                        EMPLOYEEID = e.EMPLOYEEID,
                    TAXPAYERID = e.TAXPAYERID,
                    LASTNAME = e.LASTNAME,
                    FIRSTNAME = e.FIRSTNAME,
                    HOMEPHONE = e.HOMEPHONE,
                    ADDRESS = e.ADDRESS,
                    ZIPCODE = e.ZIPCODE,
                    CITYID = e.CITYID,
                    DATEHIRED = e.DATEHIRED,
                    DATERELEASED = e.DATERELEASED,
                    CURRENTMANAGER = e.CURRENTMANAGER,
                    SALARYGRADE = e.SALARYGRADE,
                    SALARY = e.SALARY,
                    TITLE = e.TITLE,
                    WORKAREA = e.WORKAREA
                    }).FirstOrDefault<EmployeeViewModel>();
            }
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        public IHttpActionResult PostNewEmployee(EmployeeViewModel e)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.EMPLOYEEs.Add(new EMPLOYEE()
                {
                    EMPLOYEEID = e.EMPLOYEEID,
                    TAXPAYERID = e.TAXPAYERID,
                    LASTNAME = e.LASTNAME,
                    FIRSTNAME = e.FIRSTNAME,
                    HOMEPHONE = e.HOMEPHONE,
                    ADDRESS = e.ADDRESS,
                    ZIPCODE = e.ZIPCODE,
                    CITYID = e.CITYID,
                    DATEHIRED = e.DATEHIRED,
                    DATERELEASED = e.DATERELEASED,
                    CURRENTMANAGER = e.CURRENTMANAGER,
                    SALARYGRADE = e.SALARYGRADE,
                    SALARY = e.SALARY,
                    TITLE = e.TITLE,
                    WORKAREA = e.WORKAREA
                });

                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
