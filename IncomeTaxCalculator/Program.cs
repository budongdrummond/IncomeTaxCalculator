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
            //decimal validIncome; //variable to store users input for their income
            var inputStyle = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.Number; //enumeration values that indicates the permitted format
            var inputCulture = CultureInfo.CreateSpecificCulture("en-GB");

            do
            {
                Console.WriteLine("\n*** Welcome to your income prediction machine, it wont be 100% accurate, but, it will be very close :) ***" +
                    "\nEnter 1 - To calculate if you know your pre-tax annual salary." +
                    "\nEnter 2 - To calculate your pay using hours per week basis (using living wage rate)." +
                    "\nEnter 3 - If you only get paid on monthly basis." +
                    "\nEnter 0 - To Exit programme." +
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
                            if (Decimal.TryParse(inputIncome, inputStyle, inputCulture, out decimal validIncome))
                            {
                                //Create instance of AnnualPayee type.
                                Payee payee = new AnnualPayee(validIncome);
                                payee.CalculateGrossAnnualSalary(); //invoke method. calculate gross annual income (not really needed as annual payee object already initilised from constructor).
                                payee.CalculateTax(payee); //invoke method. calculate tax from given annual salary.
                                payee.CalculateNationalInsuranceDeduction(payee); //invoke method. calculate NI from given annual salary.

                                //Console.WriteLine("Current payee object is type of >> " + payee.GetType());
                                payee.CalculateNetAnnualSalary();
                                payee.CalculateNetMonthlySalary();
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
                        var validHourlyInput = true; //condition status for annual payee menu in While loop, if false keep asking user
                        while (validHourlyInput)
                        {
                            Console.Clear();
                            Console.WriteLine("¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬");
                            Console.Write("\nHow many weeks does this pay entitles to? >> ");
                            bool inputWeekNo = int.TryParse(Console.ReadLine(),inputStyle, inputCulture, out int validWeekNo); //read input assign to validWeekNo variable.

                            Console.Write($"\nHow many hours did you worked for in that {Convert.ToString(validWeekNo)} weeks? >> ");
                            bool inputHourNo = int.TryParse(Console.ReadLine(), inputStyle, inputCulture, out int validHourNo); //read input assign to validHourNo variable.
                            Console.WriteLine("¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬");

                            //test code line to see if conversion is successful (true) or not (false).
                            //Console.WriteLine("Convert week input to integer a success? " + inputWeekNo + " ," + "Convert hour input to integer a success? " + inputHourNo);

                            //if both inputWeekNo & inputHourNo converted string to int is successfully, start process calculation. Else, try input valid values loop.
                            if (inputWeekNo && inputHourNo)
                            {
                                //Create instance of HourlyPayee type.
                                Payee payee = new HourlyPayee(validWeekNo, validHourNo);
                                HourlyPayee hourlyPayee = (HourlyPayee)payee; //downcasting to reach the CalculateCurrentPay method in HourlyPayee class.
                                hourlyPayee.CalculateCurrentPay();
                                payee.CalculateGrossAnnualSalary();
                                payee.CalculateTax(payee);
                                payee.CalculateNationalInsuranceDeduction(payee);

                                Console.WriteLine("Current payee object is type of >> " + payee.GetType());
                                payee.CalculateNetAnnualSalary();
                                payee.CalculateNetMonthlySalary();
                                Console.WriteLine(payee.ToString());
                                validHourlyInput = false;
                            }
                            else
                            {
                                Console.WriteLine($"Unable to convert number or invalid input is entered, Click any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
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
