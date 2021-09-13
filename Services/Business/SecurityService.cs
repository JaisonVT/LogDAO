using LogDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogDAO.Services.Data;

namespace LogDAO.Services.Business
{
    public class SecurityService
    {
        public bool Check(LoginModel loginModel)
        {
            SecurityDAO securityDAO = new SecurityDAO();
            bool success = securityDAO.FindUser(loginModel);

            return success;
        }
    }
}