using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class User
    {
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public int Id { set; get; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<MathExpression> ExpressionHistory { get; set; }

        protected User()
        {
            ExpressionHistory = new List<MathExpression>();
        }
        public User(string firstName, string lastName, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            ExpressionHistory = new List<MathExpression>();
        }
        public void AddToHistory(MathExpression expression)
        {
            ExpressionHistory.Add(expression);
        }
        public void DeleteFromHistiry(MathExpression expression)
        {
            ExpressionHistory.Remove(expression);
        }
    }
}