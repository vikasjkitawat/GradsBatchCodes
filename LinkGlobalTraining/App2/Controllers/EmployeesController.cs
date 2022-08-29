using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App2.Models;

namespace App2.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee(1, "Ram", 20));
            employees.Add(new Employee(2, "Sam", 30));
            employees.Add(new Employee(3, "Hari", 50));
            employees.Add(new Employee(4, "Tom", 33));
            return View(employees);
        }
    }
}