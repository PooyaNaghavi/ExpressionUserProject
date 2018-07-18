using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;      
        public UsersController(IUserRepository iUserRepository)
        {
            _userRepository = iUserRepository;  
        }
        
        [Route("Users/{userName}/Expressions")]
        [HttpGet]
        public ActionResult Expressions(string userName)
        {
            User user = _userRepository.FindByUserName(userName);
            ICollection<MathExpression> result = new Collection<MathExpression>();
            if (user != null)
            {
                ViewBag.Message = "User Found Successfully";
                result = user.ExpressionHistory;
                return View(result);
            }
            else
            {
                ViewBag.Message = "User Not Found!!";
                return View(result);
            }
           
        }
    }
}