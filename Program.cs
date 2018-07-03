using System;


namespace ConsoleApp2
{
    class Program
    {
        static string myString;
        static double answer;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter your line");
            string myString = Console.ReadLine();
            Expression expr = new Expression(myString);

            answer = expr.CalculateExprWithSubExpr();

            Console.WriteLine(answer);
            Console.ReadLine();
        }
    }
}
