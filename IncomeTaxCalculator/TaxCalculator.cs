using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace IncomeTaxCalculator
{
    class TaxCalculator
    {
        //Fields
        private readonly decimal taxDeduction = 0m;
        public decimal SalaryAfterTax { get; set; }
        public decimal[] TaxPercents
        {
            //retrieve the tax rate array from static Class TaxBands
            get
            {
                return TaxBands.GetTaxPercentsDetails();
            }
        }
        public decimal[] MaxThresholds
        {
            //retrieve the earning thresholds array from static Class TaxBands
            get
            {
                return TaxBands.GetMaxThresholdsDetails();
            }
        }

        /* Method to display the array of information about tax rates and earning thresholds.
         * Bad coding (line.40), relies on 2 different arrays in a for loops, potential crash if elements number isn't matching in both arrays. */
        public void DisplayTaxPercentsMaxThresholdsDetails()
        {
            Console.WriteLine("Tax Rates (Lowest to Highest) >> ");
            if (TaxPercents.Length == MaxThresholds.Length)
            {
                for (int i = 0; i < TaxPercents.Length; i++) //bad bad bad, cannot depend on the lengths value off two different arrays!
                {
                    if (i == 0)
                    {
                        Console.WriteLine($"- Anything from £{MaxThresholds[i]} to £{MaxThresholds[i+1]} is tax-exempt ({TaxPercents[i] * 100}%)");
                    }
                    if (i > 0)
                    {
                        Console.WriteLine($"- Earning above £{MaxThresholds[i]} is taxable at the rate of {TaxPercents[i] * 100}%");
                    }                    
                }
            }
            else
            {
                Console.WriteLine("Error - please check the number elements in TaxPercents & MaxThresholds arrays in TaxBands Class is Matching");
            }
        }
        
        public decimal CalculateTax(decimal grossIncome)
        {
            for (int i = 0; i < MaxThresholds.Length; i++)
            {
                if (grossIncome > MaxThresholds[i])
                {

                }
            }
            return 0;
        }
    }
}
