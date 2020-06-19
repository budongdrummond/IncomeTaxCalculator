using System;

namespace IncomeTaxCalculator
{
    /// <summary>
    /// Properties such as GrossAnnualSalary, TotalTaxAndNationalInsuranceAmount, NetAnnualSalary, and,
    /// NetMonthlySalary are inherited from Payee base class.
    /// If the user have an annual fix income then this is is class where the income tax calculated.
    /// </summary>
    class AnnualPayee : Payee
    {
        /// <summary>
        /// No calculation if user is on an annual based fixed income
        /// </summary>
        public override void CalculateGrossAnnualSalary(decimal income)
        {
            GrossAnnualSalary = income;
        }
        public override void CalculateNationalInsuranceDeduction(decimal grossIncome)
        {
            throw new NotImplementedException();
        }
        public override void CalculateTax(decimal grossIncome)
        {
            throw new NotImplementedException();
        }
    }
}
