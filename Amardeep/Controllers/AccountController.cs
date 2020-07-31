using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
namespace EmployeeManagement.Controllers
{
    public class AccountController : Controller
    {
        readonly EMSDataContext _database = new EMSDataContext();


        public IActionResult Index()
        {
            //LogonModel model = new LogonModel() { Username = "amardeep", Password="master" };
            //return View(model);

            return View();
        }

        public IActionResult Login(UserModel model)
        {            
            if(!ModelState.IsValid)
                return View("~/Views/Account/Index.cshtml", model);

            //var sql = from user in _database.Users
            //          where user.Username == model.Username && user.Password == model.Password
            //          select user;
            //if (sql.Count() > 0)
            //{
                HttpContext.Session.SetString(SessionManager.SessionUserName,"AMARDEEP");


                return RedirectToAction("index", "employee");

            //}

            //return View("~/Views/Account/Index.cshtml", model);
        }


    }
}