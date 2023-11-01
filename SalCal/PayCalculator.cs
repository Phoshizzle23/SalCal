using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalCal
{
    /// <summary>
    /// Represents a Pay Calculator class that provides methods for calculating various payroll-related values.
    /// </summary>
    public class PayCalculator
    {
        private PaySlip paySlip;

        /// <summary>
        /// Initializes a new instance of the PayCalculator class and creates a PaySlip object.
        /// </summary>
        public PayCalculator()
        {
            paySlip = new PaySlip();
        }

        /// <summary>
        /// Calculates the gross pay based on the hours worked and hourly rate.
        /// </summary>
        /// <param name="hoursWorked">The number of hours worked.</param>
        /// <param name="hourlyRate">The hourly rate of pay.</param>
        /// <returns>The calculated gross pay.</returns>
        public double CalculateGrossPay(double hoursWorked, double hourlyRate)
        {
            return hoursWorked * hourlyRate;
        }

        /// <summary>
        /// Calculates the tax amount based on the gross pay and tax rate method.
        /// </summary>
        /// <param name="grossPay">The gross pay amount.</param>
        /// <param name="taxRateMethod">The tax rate method ('Y' for thresholds, 'N' for no thresholds).</param>
        /// <returns>The calculated tax amount.</returns>
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

        /// <summary>
        /// Calculates the tax amount with income thresholds.
        /// </summary>
        /// <param name="grossPay">The gross pay amount.</param>
        /// <returns>The calculated tax amount with thresholds.</returns>
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
                    taxAmount = ((grossPay + 0.99) * taxRate) - additionalConstant;
                    break;
                }
            }

            return taxAmount;
        }

        /// <summary>
        /// Calculates the tax amount without income thresholds.
        /// </summary>
        /// <param name="grossPay">The gross pay amount.</param>
        /// <returns>The calculated tax amount without thresholds.</returns>
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
                    taxAmount = ((grossPay + 0.99) * taxRate) - additionalConstant;
                    break;
                }
            }

            return taxAmount;
        }

        /// <summary>
        /// Calculates the net pay based on the gross pay and tax amount.
        /// </summary>
        /// <param name="grossPay">The gross pay amount.</param>
        /// <param name="taxAmount">The tax amount.</param>
        /// <returns>The calculated net pay.</returns>
        public double CalculateNetPay(double grossPay, double taxAmount)
        {
            return grossPay - taxAmount;
        }

        /// <summary>
        /// Calculates the superannuation amount based on the gross pay and superannuation rate.
        /// </summary>
        /// <param name="grossPay">The gross pay amount.</param>
        /// <param name="superRate">The superannuation rate.</param>
        /// <returns>The calculated superannuation amount.</returns>
        public double CalculateSuperannuation(double grossPay, double superRate)
        {
            return grossPay * superRate;
        }
    }
}
