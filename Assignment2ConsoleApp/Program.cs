using System;

namespace Assignment2ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string op;
            do
            {
                // Ask the user to choose an operator.
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Factorial");
                Console.WriteLine("\tb - Armstrong number");
                Console.WriteLine("\tc - Decimal to binary");
                Console.Write("Your option? ");

                // Reading user responce
                op = Console.ReadLine();

                try
                {
                    Operations.DoOperation(op);
                    Console.WriteLine("\n-----------------------------------------\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

            } while(op == "y");
            
            return;
        }
    }
}