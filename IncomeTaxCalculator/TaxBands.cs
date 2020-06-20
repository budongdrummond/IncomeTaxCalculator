using System;
using System.Collections.Generic;

namespace IncomeTaxCalculator
{
    static class TaxBands
    {
        //Fields
        //private const decimal topRateMinThreshold = 150000m;
        //private const decimal higherMinRateThreshold = 43431m;
        //private const decimal intermediateMinRateThreshold = 25158m;
        //private const decimal basicRateMinThreshold = 12501m;
        //private const decimal starterRateMinThreshold = 0m;

        //private const decimal topRateTaxableValue = 0.46m;
        //private const decimal higherRateTaxableValue = 0.41m;
        //private const decimal intermediateRateTaxableValue = 0.46m;
        //private const decimal basicRateTaxableValue = 0.46m;
        //private const decimal starterRateTaxableValue = 0.00m;

        //var taxBands = new[]
        //{
        //    new { Lower = 0m, Upper = 10999m, Rate = 0.0m },
        //    new { Lower = 11000m, Upper = 43000m, Rate = 0.2m },
        //    new { Lower = 43001m, Upper = 150000m, Rate = 0.4m },
        //    new { Lower = 150001m, Upper = decimal.MaxValue, Rate = 0.45m }
        //};

        private static readonly decimal[] taxPercents = { 0.00m, 0.19m, 0.20m, 0.21m, 0.41m, 0.46m };
        private static readonly decimal[] maxThresholds = { 0m, 12501m, 14585, 25158m, 43431m, 150000m };

        //Methods
        public static decimal[] GetTaxPercentsDetails()
        {
            return taxPercents;
        }
        public static decimal[] GetMaxThresholdsDetails()
        {
            return maxThresholds;
        }
    }
}
