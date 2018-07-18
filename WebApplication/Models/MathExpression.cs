using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace WebApplication.Models
{
    public class MathExpression : IMathExpression
    {
        public User Owner { get; private set; }
        public int Id { get; private set; }
        public string Expression { get; set; }
        public DateTime ArrivedAt { get; set; }
        public DateTime ExitedAt { get; set; }
        public bool IsSuccessful { get; set; }

        protected MathExpression()
        {

        }
        public MathExpression(User user, string inputExpression)
        {
            Expression = inputExpression;
            ArrivedAt = DateTime.Now;
            Owner = user;
        }

        public string Value()
        {
            return Expression;
        }
    }
    public interface IMathExpression
    {
        string Value();
    }
}