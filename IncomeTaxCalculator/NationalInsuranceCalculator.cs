using System.Collections.Generic;

namespace IncomeTaxCalculator
{
    /// <summary>
    /// in this class we are going to calculate the national insurance contribution from the groos annual salary.
    /// to start with, we would ideally need to know the exact or estimated gross annual salary first in order to calculate NI contribution.
    /// it simply uses NI contribution bracket to calculate how much your gross annual income would be taken off. This brackets/rates are represented using array in the fields.
    /// calculation can be made similar to the one seen in Tax Calculator class.
    /// </summary>
    class NationalInsuranceCalculator
    {
        //Fields
        private readonly decimal niLowerPrimaryWeeklyThreshold = 183.00m;
        private readonly decimal niUpperPrimaryWeeklyThreshold = 962.00m;

        //Properties
        public decimal TotalNIAnnualContribution { get; protected set; }

        /* need to calculate the weekly income (annual gross / 52).
         * using that figure to logically place the person category of NI contribution rate.
         * take annual gross minus the first-free £183 to move on to calculate the next NI contribution rate which is 12%, and so on...*/

        //Method to calculate NI contribution with object of Type Payee passed-in.
        public void CalculateNIContribution(Payee payee)
        {
            var grossAnnualIncome = payee.GrossAnnualSalary;
            var grossWeeklyIncome = CalculateWeeklyIncome(grossAnnualIncome);

            //List<decimal> remainingValueOfWeeklySalary = new List<decimal> { grossWeeklyIncome };
            
            if (grossWeeklyIncome < niLowerPrimaryWeeklyThreshold)
            {
                TotalNIAnnualContribution = 0.00m;
            }
            else if (grossWeeklyIncome >= niLowerPrimaryWeeklyThreshold && grossWeeklyIncome <= niUpperPrimaryWeeklyThreshold)
            {
                var niWeeklyDeduction = (grossWeeklyIncome - niLowerPrimaryWeeklyThreshold) * 0.12m;
                TotalNIAnnualContribution =  CalculateNIAnnualDeduction(niWeeklyDeduction);
            }
            else if (grossWeeklyIncome > niUpperPrimaryWeeklyThreshold)
            {
                var niWeeklyDeduction = (grossWeeklyIncome - niLowerPrimaryWeeklyThreshold) * 0.02m;
                TotalNIAnnualContribution = CalculateNIAnnualDeduction(niWeeklyDeduction);
            }
        }

        private decimal CalculateWeeklyIncome(decimal annualIncome)
        {
            var weeklyIncome = annualIncome / 52;
            return weeklyIncome;
        }

        private decimal CalculateNIAnnualDeduction(decimal niWeeklyDeduction)
        {
            decimal niAnnualDeduction;

            niAnnualDeduction = niWeeklyDeduction * 52;
            return niAnnualDeduction;
        }
    }
}
