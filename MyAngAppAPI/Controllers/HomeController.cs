using MyAngAppAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAngAppAPI.Controllers
{
    public class HomeController : Controller
    {

        private IEmployeeRepository _employeeRepository;
        public HomeController()
        {
            _employeeRepository = new EmployeeRepository(new Models.EmployeeContext());
        }
        //HomeController(IEmployeeRepository employeeRepository)
        //{
        //    _employeeRepository = employeeRepository;
        //}
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
