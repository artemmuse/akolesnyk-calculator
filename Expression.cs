using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Expression
    {
        private string myString;

        public Expression(string myString)
        {
            this.myString = myString;
        }
         
        public double CalculateExpressionWithoutSubExpression()
        {
            if (myString.Contains("+"))
            {
                int position = myString.LastIndexOf('+');
                Expression expr1 = new Expression(myString.Substring(0, position));
                Expression expr2 = new Expression(myString.Substring(position + 1, myString.Length - position - 1));
                return expr1.CalculateExpressionWithoutSubExpression() + expr2.CalculateExpressionWithoutSubExpression();
            }
            else if (myString.Contains("-") && (!(myString.Contains("'-"))))
            {
                int position = myString.LastIndexOf('-');
                Expression expr1 = new Expression(myString.Substring(0, position));
                Expression expr2 = new Expression(myString.Substring(position + 1, myString.Length - position - 1));
                return expr1.CalculateExpressionWithoutSubExpression() - expr2.CalculateExpressionWithoutSubExpression();
            }
            else if (myString.Contains("*"))
            {
                int position = myString.IndexOf('*');
                Expression expr1 = new Expression(myString.Substring(0, position));
                Expression expr2 = new Expression(myString.Substring(position + 1, myString.Length - position - 1));
                return expr1.CalculateExpressionWithoutSubExpression() * expr2.CalculateExpressionWithoutSubExpression();
            }
            else if (myString.Contains("?"))
            {
                int position = myString.IndexOf('/');
                Expression expr1 = new Expression(myString.Substring(0, position));
                Expression expr2 = new Expression(myString.Substring(position + 1, myString.Length - position - 1));
                return expr1.CalculateExpressionWithoutSubExpression() / expr2.CalculateExpressionWithoutSubExpression();
            }
            else
            {
                if ((myString[0] == '\'') && (myString[myString.Length-1] == '\''))
                    return Convert.ToDouble(myString.Substring(1, myString.Length - 2));
                else
                    return Convert.ToDouble(myString);
            }
            
        }

        public Boolean ExistSubExpr() {
            if (myString.Contains("(") && myString.Contains(")"))
                return true;
            else
                return false;
        }

        public string GetSubExpr() {
            int start = myString.IndexOf('(');
            int stop = myString.IndexOf(')');
            return myString.Substring(start + 1, stop - start - 1);
        }

        public double CalculateExprWithSubExpr()
        {
            while (ExistSubExpr())
            {
                Expression subExpr = new Expression(GetSubExpr());
                string subStringNew = Convert.ToString(subExpr.CalculateExpressionWithoutSubExpression());
                string subStringOld = "(" + subExpr.myString + ")";
                myString = myString.Replace(subStringOld, "'"+subStringNew+"'");
            }
            return CalculateExpressionWithoutSubExpression();
        }
          
    }
}