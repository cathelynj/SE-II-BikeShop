using BikeShop.Models;
using BikeShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

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
                    EmployeeID = e.EMPLOYEEID,
                    TaxpayerID = e.TAXPAYERID,
                    LastName = e.LASTNAME,
                    FirstName = e.FIRSTNAME,
                    HomePhone = e.HOMEPHONE,
                    Address = e.ADDRESS,
                    ZipCode = e.ZIPCODE,
                    CityID = e.CITYID,
                    DateHired = e.DATEHIRED,
                    DateReleased = e.DATERELEASED,
                    CurrentManager = e.CURRENTMANAGER,
                    SalaryGrade = e.SALARYGRADE,
                    Salary = e.SALARY,
                    Title = e.TITLE,
                    Workarea = e.WORKAREA
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
                        EmployeeID = e.EMPLOYEEID,
                        TaxpayerID = e.TAXPAYERID,
                        LastName = e.LASTNAME,
                        FirstName = e.FIRSTNAME,
                        HomePhone = e.HOMEPHONE,
                        Address = e.ADDRESS,
                        ZipCode = e.ZIPCODE,
                        CityID = e.CITYID,
                        DateHired = e.DATEHIRED,
                        DateReleased = e.DATERELEASED,
                        CurrentManager = e.CURRENTMANAGER,
                        SalaryGrade = e.SALARYGRADE,
                        Salary = e.SALARY,
                        Title = e.TITLE,
                        Workarea = e.WORKAREA
                    }).FirstOrDefault<EmployeeViewModel>();
            }
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        public IHttpActionResult PostNewEmployee(EmployeeViewModel employee)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new BikeShopEntities())
            {
                ctx.EMPLOYEEs.Add(new EMPLOYEE()
                {
                    EMPLOYEEID = employee.EmployeeID,
                    TAXPAYERID = employee.TaxpayerID,
                    LASTNAME = employee.LastName,
                    FIRSTNAME = employee.FirstName,
                    HOMEPHONE = employee.HomePhone,
                    ADDRESS = employee.Address,
                    ZIPCODE = employee.ZipCode,
                    CITYID = employee.CityID,
                    DATEHIRED = employee.DateHired,
                    DATERELEASED = employee.DateReleased,
                    CURRENTMANAGER = employee.CurrentManager,
                    SALARYGRADE = employee.SalaryGrade,
                    SALARY = employee.Salary,
                    TITLE = employee.Title,
                    WORKAREA = employee.Workarea
                });

                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
