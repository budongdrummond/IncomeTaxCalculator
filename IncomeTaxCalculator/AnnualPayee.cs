using System;

namespace IncomeTaxCalculator
{
    /// <summary>
    /// Properties such as GrossAnnualSalary, TotalTaxAndNationalInsuranceAmount, NetAnnualSalary, and,
    /// NetMonthlySalary are inherited from Payee base class.
    /// If the user have an annual fix income then this is is class where the income tax and national insurance calculated.
    /// All results would be stored in the properties in base class.
    /// </summary>
    class AnnualPayee : Payee
    {
        //Constructor
        public AnnualPayee(decimal validIncome)
            : base (validIncome)
        {
            //no further implementation within derived class.
        }

        public override void CalculateGrossAnnualSalary()
        {
            //no further calculation for annualPayee object as annual salary is already known.
        }

        /// <summary>
        /// invoke calculate tax method within the taxCalculator class. assign returned value into Inherited TotalTaxAmount property.
        /// </summary>
        /// <param name="payee"></param>
        public override void CalculateTax(Payee payee)
        {
            var taxCalculator = new TaxCalculator(); //create new instance of Type TaxCalculator.
            TotalTaxAmount = Math.Round(taxCalculator.CalculateTax(payee),2); //rounding the result into 2 decimal places.
        }

        /// <summary>
        /// invoke calculate NI method within the NI Calculator class. assign returned value into Inherited Total NI Amount property.
        /// </summary>
        /// <param name="payee"></param>
        public override void CalculateNationalInsuranceDeduction(Payee payee)
        {
            var niCalculator = new NationalInsuranceCalculator(); //create new instance of Type NICalculator.
            niCalculator.CalculateNIContribution(payee);
            TotalNationalInsuranceAmount = Math.Round(niCalculator.TotalNIAnnualContribution, 2); //rounding the result into 2 decimal places.
        }

        public override string ToString()
        {
            return "¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬" + "\n" +
                "The gross annual salary of £" + this.GrossAnnualSalary + "\n" + //format decimal variable to 2 decimal places when converted into string.
                "Total Tax Deduction is £" + TotalTaxAmount + "\n" +
                "Total National Insurance Deduction is £" + TotalNationalInsuranceAmount + "\n"+
                "The net annual salary is £" + NetAnnualSalary + "\n" +
                "The net monthly salary is £" + NetMonthlySalary + "\n" +
                "¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬";
        }
    }
}
