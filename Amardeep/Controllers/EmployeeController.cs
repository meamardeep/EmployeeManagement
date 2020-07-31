using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        EMSDataContext _database = new EMSDataContext();

        public IActionResult Index()
        {
            //List<EmployeeModel> employees = new List<EmployeeModel>();
            //employees.Add(new EmployeeModel() { EmployeeId =1, EmployeeName = "ABC" });
            //employees.Add(new EmployeeModel() { EmployeeId = 2, EmployeeName = "XYZ" });
            //employees.Add(new EmployeeModel() { EmployeeId = 3, EmployeeName = "PQR" });


            //SQL
            //Select e.*from Employees e

            //LINQ SQL
            //from e in _database.Employees select e;
            var employees = from e in _database.Employees
                            select new EmployeeModel {
                                EmployeeId = e.EmployeeId,
                                EmployeeName = e.EmployeeName
                            };


            //List<EmployeeModel> uiEmployees = new List<EmployeeModel>();


            //Copy Data From Entity Class (i.e. Database Class) to UI Model Class
            //foreach (var dbEmployee in dbEmployees)
            //{
            //    uiEmployees.Add(new EmployeeModel() { EmployeeId = dbEmployee.EmployeeId,
            //        EmployeeName = dbEmployee.EmployeeName });
            //}



            ViewBag.Name = HttpContext.Session.GetString(SessionManager.SessionUserName);

            return View(employees.ToList());
        }

        [ActionName("new-employee")]
        public IActionResult NewEmployee()
        {
            EmployeeModel model = new EmployeeModel();
            return View("~/Views/Employee/NewEmployee.cshtml", model);
        }

        public IActionResult SaveEmployee(EmployeeModel model)
        {
            //Copy from UI Model to DB Model
            Employee dbEmployee = new Employee() { EmployeeName = model.EmployeeName };


            _database.Employees.Add(dbEmployee);
            _database.SaveChanges();

            return RedirectToAction("index");
        }
    }
}