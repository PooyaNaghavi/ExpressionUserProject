using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private int _intFirstName;
        private int _intLastName;
        private readonly IExpressionCalculator _expressionCalculator;
        private readonly IUserRepository _userRepository;
        private readonly IExpressionRepository _expressionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IExpressionCalculator iExpression, IUserRepository iUserRepository, IExpressionRepository iEpressionRepository, IUnitOfWork iUnitOfWork)
        {
            _intFirstName = 1;
            _intLastName = 1;
            _expressionCalculator = iExpression;
            _userRepository = iUserRepository;
            _expressionRepository = iEpressionRepository;
            _unitOfWork = iUnitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }
        public class ComplexInput
        {
            public int num1 { get; set; }
            public int num2 { get; set; }
        }
        public ActionResult PlusGet(ComplexInput c)
        {
            HttpRequestBase r = Request;
            //string num1 = Request.Params["num1"];
            //string num2 = Request.Params["num2"];
            ViewBag.Message1 = c.num1;
            ViewBag.Message2 = c.num2;
            //int result = Int32.Parse(num1) + Int32.Parse(num2);

            ViewBag.Message3 = c.num1 + c.num2;
            return View(c.num1 + c.num2);
        }
        [HttpPost]
        public ActionResult Plus(string query, string userName, string password, string searchId)
        {
            double result = 0;
            //User temp = _userRepository.FindById(1);
            //User searchableUser = _userRepository.FindById(Int32.Parse(searchId));
            User searchableUser = _userRepository.FindByUserName(userName);
            
            MathExpression expression;

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            var sha1 = SHA1.Create();
            byte[] passwordHashBytes = sha1.ComputeHash(passwordBytes);
            string newPassword = System.Text.Encoding.Default.GetString(passwordHashBytes);

            if (searchableUser != null)
            {
                expression = new MathExpression(searchableUser, query);
                searchableUser.AddToHistory(expression);

            }
            else
            {
               
                searchableUser = new User("A"+_intFirstName.ToString(), "A"+_intLastName.ToString(), userName, newPassword);
                _intFirstName += 1;
                _intLastName += 1;
                expression = new MathExpression(searchableUser, query);

                searchableUser.AddToHistory(expression);
                _userRepository.Add(searchableUser);
            }

            try
            {
                result = _expressionCalculator.FindResult(expression);
                expression.ExitedAt = DateTime.Now;
                expression.IsSuccessful = true;

            }catch(Exception ex)
            {
                expression.ExitedAt = DateTime.Now;
                expression.IsSuccessful = false;
            }

            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Username should be Unique.");
            }
            var r = searchableUser.ExpressionHistory;
            var tupleResult = Tuple.Create<string, double, ICollection<MathExpression>>(query, result, r);
            return View(tupleResult);

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}