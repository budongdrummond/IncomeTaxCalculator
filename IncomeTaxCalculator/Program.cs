using System;
using System.Globalization;

namespace IncomeTaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            

            bool keepAsking = true ;
            decimal validNumber;
            var inputIncomeStyle = NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol | NumberStyles.Number;
            var inputIncomeCulture = CultureInfo.CreateSpecificCulture("en-GB");

            while (keepAsking)
            {
                Console.WriteLine("*** Welcome to your income prediction machine, it wont be 100% accurate, but, it will be very close :) ***");
                Console.WriteLine("\nPlease insert your annual pre-tax income, you may use ',' to seperates thousands:");
                var inputIncome = Console.ReadLine();

                if (Decimal.TryParse(inputIncome, inputIncomeStyle, inputIncomeCulture, out validNumber))
                {
                    Console.WriteLine($"You have entered a pre-tax income of £{validNumber}");
                    keepAsking = false;
                }
                else
                {
                    Console.WriteLine($"Unable to convert number or invalid input is entered, Click any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
