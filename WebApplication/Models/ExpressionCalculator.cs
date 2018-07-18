using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApplication.Models
{
    public class ExpressionCalculator : IExpressionCalculator
    {
        public IMathExpression Expression { get; set; }
        
        private string[] ChangePresistance(string[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].Equals("+"))
                    numbers[i] = "b";
                else if (numbers[i].Equals("-"))
                    numbers[i] = "a";
                else if (numbers[i].Equals("*"))
                    numbers[i] = "e";
                else if (numbers[i].Equals("/"))
                    numbers[i] = "d";
            }
            return numbers;
        }
        private List<String> ConvertToPostfix()
        {

            List<string> resultVariable = new List<string>();
            List<string> stack = new List<string>();
            string[] numbers = Regex.Split(Expression.Value(), "(?<=[-+*/])|(?=[-+*/])");
            numbers = ChangePresistance(numbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!numbers[i].Equals("a") && !numbers[i].Equals("b") && !numbers[i].Equals("d") && !numbers[i].Equals("e"))
                {
                    resultVariable.Add(numbers[i]);
                }
                else
                {
                    int j = 0;
                    if (stack.Count != 0)
                    {
                        j = stack.Count - 1;
                        if (stack[j][0] + 1 >= numbers[i][0])
                        {
                            for (int k = 0; k < stack.Count; k++)
                            {
                                resultVariable.Add(stack[k]);

                            }
                            stack.Clear();
                            stack.Insert(0, numbers[i]);
                        }
                        else
                        {
                            while (stack[j][0] <= numbers[i][0] + 1)
                            {
                                j--;
                                if (j < 0)
                                    break;
                            }
                            j++;
                            stack.Insert(j, numbers[i]);
                        }
                    }
                    else
                    {
                        stack.Insert(j, numbers[i]);
                    }

                }
            }
            for (int i = 0; i < stack.Count; i++)
            {
                resultVariable.Add(stack[i]);
            }
            return resultVariable;
        }
        public double Evaluate(double num1, double num2, string op)
        {
            if (op.Equals("b"))
                return num1 + num2;
            if (op.Equals("a"))
                return num1 - num2;
            if (op.Equals("e"))
                return num1 * num2;
            if (op.Equals("d"))
                return num1 / num2;
            return 0;
        }
        private double evaluatePostfix(List<string> postfix)
        {
            List<string> stack = new List<string>();
            for (int i = 0; i < postfix.Count; i++)
            {
                if (!postfix[i].Equals("a") && !postfix[i].Equals("b") && !postfix[i].Equals("d") && !postfix[i].Equals("e"))
                {
                    stack.Add(postfix[i]);
                }
                else
                {
                    double num1 = Convert.ToDouble(stack[stack.Count - 1]);
                    double num2 = Convert.ToDouble(stack[stack.Count - 2]);
                    stack.RemoveAt(stack.Count - 1);
                    stack.RemoveAt(stack.Count - 1);
                    double newResult = Evaluate(num1, num2, postfix[i]);
                    stack.Add(newResult.ToString());
                }
            }
            if (stack.Count != 1)
                throw new System.Exception();
            return Convert.ToDouble(stack[stack.Count - 1]);
        }

        public double FindResult(IMathExpression input)
        {
            Expression = input;

            List<string> postfixResult = ConvertToPostfix();

            return evaluatePostfix(postfixResult);
        }
    }
}