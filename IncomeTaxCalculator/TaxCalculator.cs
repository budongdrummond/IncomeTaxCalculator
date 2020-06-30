using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace IncomeTaxCalculator
{
    /// <summary>
    /// payee of type Payee has properties called GrossAnnualSalary. once we have this properties we can calculate how much
    /// tax we have to pay before we can get a net annual salary.
    /// 
    /// for e.g.,. using 30,000 annual income. Loop to calculate each related element [i] in the declared arrays. 
    /// get how much tax deducted for each tax bands (BUT, for after each tax bands \n
    /// you will need to subtract your leftover salary by the value of max and min thresholds of each relevant tax rates) & total it up.
    /// 
    /// 1. on 0% rate, with personal allowance amount of £12,500.
    /// -- calculate how much we get taxed in the next tax band we have to deduct 17,500 from taxable amount for the next tax band
    /// 2. on 19% rate, with the taxable amount of £2,084. Deduct 17,500 from taxable amount for the next tax band
    /// 3. on 20% rate, with the taxable amount of £10,573. Deduct 15,416 from taxable amount for the next tax band, if applicable.
    /// 4. on 21% rate, with the taxable amount of £18,272....
    /// 5. on 41% rate, with the taxable amount of £106,569...
    /// 6. on 46% rate, with the taxable amount of anything over £150,000.
    /// </summary>
    /// <returns></returns>
    class TaxCalculator
    {
        public decimal CalculateTax(Payee payee)
        {
            /*another way to create calculation of tax using anonymous/undefined type - but to be investigated - basically you can use foreach loop to start the calculation method.*/
            
            //var taxBands = new[]
            //{
            //    new { Lower = 0m, Upper = 10999m, Rate = 0.0m },
            //    new { Lower = 11000m, Upper = 43000m, Rate = 0.2m },
            //    new { Lower = 43001m, Upper = 150000m, Rate = 0.4m },
            //    new { Lower = 150001m, Upper = decimal.MaxValue, Rate = 0.45m }
            //};
            //Console.WriteLine(taxBands[0].Lower);

            
            decimal totalTaxDeduction = 0.00m; //variable to contain the addition of total tax deduction. initialised with 0.00.
            decimal[] taxMinThresholdRate = { 0.00m, 12501m, 14586m, 25159m, 43431m, 150001m }; //array to hold the min thresholds value for each 6 bands of tax rate.
            decimal[] taxMaxThresholdRate = { 12500m, 14585m, 25158m, 43430m, 150000m, 150000000.0m }; //array to hold the max thresholds value for each 6 bands of tax rate.
            decimal[] taxPercentsRate = { 0.00m, 0.19m, 0.20m, 0.21m, 0.41m, 0.46m }; //array to hold the tax rate value for each 6 bands of tax rate.
            List<decimal> remainingValueOfSalary = new List<decimal> { payee.GrossAnnualSalary }; //list (with initial of annual salary) withhold remaining salary for each tax bands calculation.

            //iterate through (& calculate tax due) each tax bands and calculate total tax owned at the end. 
            for (int i = 0; i < taxPercentsRate.Length; i++)
            {
                //if users income within personal allowance then return 0 for the total tax deduction.
                if (payee.GrossAnnualSalary >= 0 && payee.GrossAnnualSalary <= 12500)
                {
                    Console.WriteLine("¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬");
                    Console.WriteLine($"Your income is within '20-'21 personal allowance. 0% tax will be applied");
                    Console.WriteLine("¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬");
                    return totalTaxDeduction;
                }
                //if users income outwith personal allowance then calculate tax due & return the total tax deduction.
                else if (payee.GrossAnnualSalary > 12500.00m)
                {
                    decimal taxDeduction;

                    //as long the amount in the remaining salary if higher then the taxable amount in the next tax rate, calculate those taxes
                    if (remainingValueOfSalary[i] > taxMaxThresholdRate[i] - taxMinThresholdRate[i])
                    {
                        //calculate the current tax bracket from min & max thresholds multiply with current tax bracket rate. result in tax deduction for the current bracket.
                        taxDeduction = (taxMaxThresholdRate[i] - taxMinThresholdRate[i]) * taxPercentsRate[i];
                        Console.WriteLine($"Tax deduction for your earning between £{taxMinThresholdRate[i]} - £{taxMaxThresholdRate[i]} is £{taxDeduction}.");
                        //increment the value of current tax bracket tax deduction to the total tax deduction.
                        totalTaxDeduction += taxDeduction;
                        //get remaining value of salary (then add to remaining salary List to have value for next loop) before moving on to the next tax bracket.
                        remainingValueOfSalary.Add(remainingValueOfSalary[i] - (taxMaxThresholdRate[i] - taxMinThresholdRate[i]));
                    }
                    //else calculate the remaining salary after deduction with the last tax rate. add result to total tax deduction.
                    else if (remainingValueOfSalary[i] < taxMaxThresholdRate[i] - taxMinThresholdRate[i])
                    {
                        if (remainingValueOfSalary[i] == 0)
                        {
                            Console.WriteLine("¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬¬");
                            break;
                        }
                        else
                        {
                            decimal taxOnLastRemainingSalary;
                            taxOnLastRemainingSalary = remainingValueOfSalary[i] * taxPercentsRate[i];
                            totalTaxDeduction += taxOnLastRemainingSalary;
                            Console.WriteLine($"Tax deduction for your last remainder salary of £{remainingValueOfSalary[i]} is £{taxOnLastRemainingSalary}.");
                            remainingValueOfSalary.Add(0); //last remaining salary should be zero.
                        }
                    }
                }
            }
            return totalTaxDeduction;
        }
    }
}
