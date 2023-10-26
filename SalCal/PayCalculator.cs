using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalCal
{
    class PayCalculator
    {
        private PaySlip paySlip;

        public PayCalculator()
        {
            paySlip = new PaySlip();
        }

        public double CalculateGrossPay(double hoursWorked, double hourlyRate)
        {
            return hoursWorked * hourlyRate;
        }

        public double CalculateTax(double grossPay, string taxRateMethod)
        {
            double taxAmount = 0;

            if (taxRateMethod == "Y")
            {
                taxAmount = CalculateTaxWithThresholds(grossPay);
            }
            else
            {
                taxAmount = CalculateTaxWithoutThresholds(grossPay);
            }

            return taxAmount;
        }

        private double CalculateTaxWithThresholds(double grossPay)
        {
            double taxAmount = 0;
            double[,] taxRatesWithThresholds = paySlip.TaxRatesWithThresholds;

            for (int i = 0; i < taxRatesWithThresholds.GetLength(0); i++)
            {
                double minIncome = taxRatesWithThresholds[i, 0];
                double maxIncome = taxRatesWithThresholds[i, 1];
                double taxRate = taxRatesWithThresholds[i, 2];
                double additionalConstant = taxRatesWithThresholds[i, 3];

                if (grossPay >= minIncome && grossPay < maxIncome)
                {
                    taxAmount = (grossPay * taxRate) + additionalConstant;
                    break;
                }
            }

            return taxAmount;
        }

        private double CalculateTaxWithoutThresholds(double grossPay)
        {
            double taxAmount = 0;
            double[,] taxRatesWithoutThresholds = paySlip.TaxRatesWithoutThresholds;

            for (int i = 0; i < taxRatesWithoutThresholds.GetLength(0); i++)
            {
                double minIncome = taxRatesWithoutThresholds[i, 0];
                double maxIncome = taxRatesWithoutThresholds[i, 1];
                double taxRate = taxRatesWithoutThresholds[i, 2];
                double additionalConstant = taxRatesWithoutThresholds[i, 3];

                if (grossPay >= minIncome && grossPay < maxIncome)
                {
                    taxAmount = (grossPay * taxRate) + additionalConstant;
                    break;
                }
            }

            return taxAmount;
        }

        public double CalculateNetPay(double grossPay, double taxAmount)
        {
            return grossPay - taxAmount;
        }

        public double CalculateSuperannuation(double grossPay, double superRate)
        {
            return grossPay * superRate;
        }
    }
}
