using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogDAO.Models;
using LogDAO.Services.Business;

namespace LogDAO.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Validation(LoginModel loginModel)
        {
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Check(loginModel);
            
            if(success)
            {
                return View("UserHome",loginModel);
            }
            {
                return View("Index");
            }
        }

    }
}