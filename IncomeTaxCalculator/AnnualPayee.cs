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
        //Constructor
        public AnnualPayee(decimal validIncome)
            : base (validIncome)
        {

        }
        /// <summary>
        /// No calculation made for gross annual salary, if, a user is on an annual based fixed income
        /// </summary>
        public override void CalculateGrossAnnualSalary()
        {
            //GrossAnnualSalary value stays the same. No further calcualtion.
        }
        public override void CalculateNationalInsuranceDeduction(decimal grossIncome)
        {
            throw new NotImplementedException();
        }
        public override void CalculateTax(decimal grossIncome)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return "Gross annual income is: £" + this.GrossAnnualSalary;
        }
    }
}
