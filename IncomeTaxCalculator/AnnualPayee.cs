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

        public override void CalculateTax(Payee payee)
        {
            var taxCalculator = new TaxCalculator(); //create new instance of TaxCalculator object.
            TotalTaxAmount = taxCalculator.CalculateTax(payee); //invoke calculate tax method within the taxCalculator class. assign returned value into Inherited TotalTaxAmount property.
        }

        public override void CalculateNationalInsuranceDeduction(Payee payee)
        {
            var niCalculator = new NationalInsuranceCalculator();
            niCalculator.CalculateNIContribution(payee); //invoke the CalculateNIContribution method.
            TotalNationalInsuranceAmount = niCalculator.TotalNIAnnualContribution;
        }

        public override string ToString()
        {
            return "¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬" + "\n" +
                "The gross annual salary of £" + this.GrossAnnualSalary.ToString("#.##") + "\n" + //format decimal variable to 2 decimal places when converted into string.
                "Total Tax Deduction is £" + TotalTaxAmount + "\n" +
                "Total National Insurance Deduction is £" + TotalNationalInsuranceAmount + "\n"+
                "The net annual salary is £" + NetAnnualSalary.ToString("#.##") + "\n" +
                "The net monthly salary is £" + NetMonthlySalary.ToString("#.##") + "\n" +
                "¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬";
        }
    }
}
