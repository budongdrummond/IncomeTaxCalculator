using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata;

namespace IncomeTaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepAskingMainMenu = true; //condition status for Main Menu in Do While loop
            decimal validIncome; //variable to store users input for their income
            var inputIncomeStyle = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.Number; //enumeration values that indicates the permitted format
            var inputIncomeCulture = CultureInfo.CreateSpecificCulture("en-GB");

            do
            {
                Console.WriteLine("\n*** Welcome to your income prediction machine, it wont be 100% accurate, but, it will be very close :) ***" +
                    "\nEnter 1 - if you know your pre-tax annual salary." +
                    "\nEnter 2 - if you only know your pre-tax monthly salary." +
                    "\nEnter 3 - if you only get paid with hourly rate." +
                    "\nEnter 0 - to Exit programme." +
                    "\n");
                //read input assign to inputMainMenu variable
                var inputMainMenu = Console.ReadLine();

                switch (inputMainMenu)
                {
                    case "1":
                        var validAnnualInput = true; //condition status for annual payee menu in While loop, if false keep asking user
                        while (validAnnualInput)
                        {
                            Console.Clear();
                            Console.Write("\nPlease insert your annual pre-tax income, you may use ',' to seperates thousands >> £");

                            //read input assign to inputIncome variable
                            var inputIncome = Console.ReadLine();

                            /*convert string representation of a number to Decimal equivelant. Using specified Styles and Culture.
                             * return value in decimal, if successful, if not, return zero. */
                            if (Decimal.TryParse(inputIncome, inputIncomeStyle, inputIncomeCulture, out validIncome))
                            {
                                //Create instance of AnnualPayee type.
                                Payee payee = new AnnualPayee(validIncome);
                                payee.CalculateGrossAnnualSalary(); //invoke method. calculate gross annual income (not really needed as annual payee object already have fixed & correct input).
                                payee.CalculateTax(payee); //invoke method. calculate tax from given annual salary                               
                                //Console.WriteLine("Current payee object is type of >> " + payee.GetType());
                                payee.CalculateNetAnnualSalary();
                                Console.WriteLine(payee.ToString());
                                validAnnualInput = false;
                            }
                            else
                            {
                                Console.WriteLine($"Unable to convert number or invalid input is entered, Click any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "0":
                        Console.WriteLine("Exiting programme...");
                        keepAskingMainMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input, please try again...");
                        Console.WriteLine("");
                        break;
                }
            } while (keepAskingMainMenu);
        }
    }
}
