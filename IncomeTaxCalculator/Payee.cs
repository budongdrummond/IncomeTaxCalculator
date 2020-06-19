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
        //Properties
        public decimal GrossAnnualSalary
        {
            get
            {
                return GrossAnnualSalary;
            }
            set
            {
                if (GrossAnnualSalary > 0)
                {
                    GrossAnnualSalary = value;
                }
                else
                {
                    GrossAnnualSalary = 0;
                }
            }
        }
        public decimal TotalTaxAndNationalInsuranceAmount { get; set; }
        public decimal NetAnnualSalary { get; set; }
        public decimal NetMonthlySalary { get; set; }

        //Methods
        public abstract void CalculateGrossAnnualSalary(decimal income);
        public abstract void CalculateTax(decimal grossIncome);
        public abstract void CalculateNationalInsuranceDeduction(decimal grossIncome);

        /// <summary>
        /// Deduct taxable amount from gross annual income to get the net annual income.
        /// </summary>
        /// <returns></returns>
        public void CalculateNetAnnualSalary()
        {
            var postTaxAndNIAmount = GrossAnnualSalary - TotalTaxAndNationalInsuranceAmount;
            NetAnnualSalary = postTaxAndNIAmount;
        }

        /// <summary>
        /// Divides net annual income by 12 to get the net monthly income.
        /// </summary>
        /// <returns></returns>
        public void CalculateNetMonthlySalary()
        {
            var monthlyNetPay = NetAnnualSalary / 12;
            NetMonthlySalary = monthlyNetPay;
        }
    }
}
