using System.Diagnostics.CodeAnalysis;
using System;

namespace IncomeTaxCalculator
{
    class HourlyPayee : Payee
    {
        private const decimal hourlyRate = 10.00m; //living wage value initialised here.
        private readonly int noOfWeeksInYear = 52; 

        public int WeeksNumbers { get; }
        private decimal CurrentPayAmount { get; set; }

        public HourlyPayee(int weeksNumber, int hoursWorked):
            base (hoursWorked)
        {
            //adjust the number of week in a year after user inserted the week value for current calculation.
            WeeksNumbers = weeksNumber;
        }

        //calculate hours per week multiply by hour rate (to get a week pay) then times 52 weeks to get annual figure.
        public override void CalculateGrossAnnualSalary()
        {
            decimal personEarned = (hourlyRate * HoursWorked) / WeeksNumbers;
            GrossAnnualSalary = personEarned * noOfWeeksInYear;
        }

        public override void CalculateNationalInsuranceDeduction(Payee payee)
        {
            var niCalculator = new NationalInsuranceCalculator();
            niCalculator.CalculateNIContribution(payee);
            TotalNationalInsuranceAmount = Math.Round(niCalculator.TotalNIAnnualContribution, 2); //rounding the result into 2 decimal places.
        }

        public override void CalculateTax(Payee payee)
        {
            var taxCalculator = new TaxCalculator();
            TotalTaxAmount = Math.Round(taxCalculator.CalculateTax(payee), 2); //rounding the result into 2 decimal places.
        }

        public void CalculateCurrentPay()
        {
            var pay = hourlyRate * HoursWorked; //pay implicitly convert int to decimal (??!)
            CurrentPayAmount = pay;
        }

        public override string ToString()
        {
            return "¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬" + "\n" +
                "The estimated annual salary is £" + GrossAnnualSalary + ". You should take around £" + NetAnnualSalary + " to your pocket annually after tax\n" +
                "You have worked " + HoursWorked + " hours, during the entire " + WeeksNumbers + " weeks. You have earned £" + CurrentPayAmount  + "\n"+
                "Estimated Total of tax deduction is £" + TotalTaxAmount + " for the year." + "\n" +
                "Estimated Total of national insurance annual deduction is £" + TotalNationalInsuranceAmount + "\n" +
                "Your 4 weekly salary (after-tax) would be roughly around £" + NetMonthlySalary + "\n" +
                "¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬";
        }
    }
}
