using Payroll_Sys.Controllers.Data;
using Payroll_Sys.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNet.Identity;


namespace Payroll_Sys.Controllers
{
  
    public class HomeController : Controller
    {
        private ApplicationDbContext context;

        public HomeController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        [Authorize(Roles = MyConstants.RoleManager)]
        public ActionResult About()
        {
            List<RegisterViewModel> registers = new List<RegisterViewModel>();

            RegisterDAO registerDAO = new RegisterDAO();


            registers = registerDAO.FetchAll();

            //var username = HttpContext.User.Identity.Name;
            //List<RegisterViewModel> registers = context.Registers.ToList();

            return View("About",registers);
        }

        [Authorize(Roles = MyConstants.RoleManager)]
        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }

        [Authorize(Roles = MyConstants.RoleManager)]
        public ActionResult SearchForName(string searchPhrase)
        {
            RegisterDAO registerDAO = new RegisterDAO();

            List<RegisterViewModel> searchResults = registerDAO.SearchForName(searchPhrase);
            return View("About", searchResults);
        }


        public ActionResult Delete(int Id)
        {
            RegisterDAO registerDAO = new RegisterDAO();
            registerDAO.Delete(Id);

            List<RegisterViewModel> registers = registerDAO.FetchAll();

            return View("About", registers);
        }  


        public ActionResult Index()
        {
            
            return View();
        }


        [Authorize(Roles = MyConstants.RoleEmployee)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Click on the link below to report any dipute.";


            return View();
        }

        //public ActionResult payslip()
        //{
           
        //    return View("payslip.aspx");
        //}



















    }
}