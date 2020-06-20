using System;
using System.Globalization;
using System.Reflection.Metadata;

namespace IncomeTaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepAskingMainMenu = true;
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

                var inputMainMenu = Console.ReadLine();

                switch (inputMainMenu)
                {
                    case "1":
                        var validAnnualInput = true;
                        while (validAnnualInput)
                        {
                            Console.Clear();
                            Console.Write("\nPlease insert your annual pre-tax income, you may use ',' to seperates thousands >> £");
                            var inputIncome = Console.ReadLine();

                            if (Decimal.TryParse(inputIncome, inputIncomeStyle, inputIncomeCulture, out validIncome))
                            {
                                //Create instance of AnnualPayee type.
                                Payee payee = new AnnualPayee(validIncome);
                                Console.WriteLine("Current object is >> " + payee.GetType() + " << & earning gross salary of £" + payee.GrossAnnualSalary + " annually.");
                                //Call methos to calculate gross annual income (not really needed).
                                payee.CalculateGrossAnnualSalary();

                                var t = new TaxCalculator();
                                Console.WriteLine("------------------------------------");
                                t.DisplayTaxPercentsMaxThresholdsDetails();
                                Console.WriteLine("------------------------------------");
                                t.CalculateTax(payee.GrossAnnualSalary);
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
