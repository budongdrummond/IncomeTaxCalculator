using System;

namespace IncomeTaxCalculator
{
    /// <summary>
    /// Abstract class to be the base class of AnnualPayee, MonthlyPayee, & HourlyPayee classes.
    /// We will have abstract methods called CalculateGrossAnnualSalary, CalculateNationalInsuranceDeduction & CalculateIncomeTax.
    /// Followed by normal methods called CalculateNetAnnualSalary and CalculateNetMonthlySalary.
    /// Override ToString() method for convinience of converting everything to String type.
    /// </summary>
    abstract class Payee
    {
        //Field
        private decimal grossAnnualSalary;
        //Properties
        public decimal GrossAnnualSalary
        {
            get
            {
                return Math.Round(grossAnnualSalary, 2); //rounding the result into 2 decimal places.
            }
            set
            {
                if (value > 0)
                {
                    grossAnnualSalary = value;
                }
                else
                {
                    grossAnnualSalary = 0;
                }
            }
        }
        public decimal TotalTaxAmount { get; set; }
        public decimal TotalNationalInsuranceAmount { get; set; }
        public decimal NetAnnualSalary { get; set; }
        public decimal NetMonthlySalary { get; set; }
        public int HoursWorked { get; set; }

        //Constructor
        public Payee(decimal validIncome)
        {
            this.GrossAnnualSalary = validIncome; //initialise salary input by user.
        }
        public Payee(int hoursWorked)
        {
            this.HoursWorked = hoursWorked;
        }

        //Methods
        public abstract void CalculateGrossAnnualSalary();
        public abstract void CalculateTax(Payee payee);
        public abstract void CalculateNationalInsuranceDeduction(Payee payee);

        /// <summary>
        /// Deduct taxable amount from gross annual income to get the net annual income.
        /// </summary>
        /// <returns></returns>
        public void CalculateNetAnnualSalary()
        {
            var postTaxAndNIAmount = GrossAnnualSalary - TotalTaxAmount - TotalNationalInsuranceAmount;
            NetAnnualSalary = Math.Round(postTaxAndNIAmount, 2); //rounding the result into 2 decimal places.
        }

        /// <summary>
        /// Divides net annual income by 12 to get the net monthly income.
        /// </summary>
        /// <returns></returns>
        public void CalculateNetMonthlySalary()
        {
            var monthlyNetPay = NetAnnualSalary / 12;
            NetMonthlySalary = Math.Round(monthlyNetPay, 2); //rounding the result into 2 decimal places.
        }
    }
}
