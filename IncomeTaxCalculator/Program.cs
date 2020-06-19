using System;

namespace IncomeTaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Welcome to your income prediction machine, it wont be 100% accurate, but, it will be very close :) ***");
        }
    }
    /// <summary>
    /// Abstract class to be the base class of AnnualPayee, MonthlyPayee, & HourlyPayee classes.
    /// We will have abstract methods called CalculateGrossAnnualSalary, CalculateNationalInsuranceDeduction & CalculateIncomeTax.
    /// Followed by normal methods called CalculateNetAnnualSalary and CalculateNetMonthlySalary
    /// </summary>
    abstract class Payee
    {
        //Properties
    }
}
