using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csv;

namespace SalCal
{
    /// <summary>
    /// Represents a PaySlip class responsible for managing tax rate data and reading from CSV files.
    /// </summary>
    class PaySlip
    {
        /// <summary>
        /// Gets or sets tax rates with income thresholds.
        /// </summary>
        public double[,] TaxRatesWithThresholds { get; private set; }

        /// <summary>
        /// Gets or sets tax rates without income thresholds.
        /// </summary>
        public double[,] TaxRatesWithoutThresholds { get; private set; }

        /// <summary>
        /// Initializes a new instance of the PaySlip class and populates tax rate data.
        /// </summary>
        public PaySlip()
        {
            // Call methods to read tax rate data files and populate the class
            PopulateTaxRatesWithThresholds();
            PopulateTaxRatesWithoutThresholds();
        }

        /// <summary>
        /// Populates tax rates with income thresholds from a CSV file.
        /// </summary>
        private void PopulateTaxRatesWithThresholds()
        {
            string taxRateDataFile = "taxrate-withthreshold.csv";
            TaxRatesWithThresholds = ReadTaxRateData(taxRateDataFile);
        }

        /// <summary>
        /// Populates tax rates without income thresholds from a CSV file.
        /// </summary>
        private void PopulateTaxRatesWithoutThresholds()
        {
            string taxRateDataFile = "taxrate-nothreshold.csv";
            TaxRatesWithoutThresholds = ReadTaxRateData(taxRateDataFile);
        }

        /// <summary>
        /// Reads tax rate data from a CSV file and returns a two-dimensional array.
        /// </summary>
        /// <param name="fileName">The name of the CSV file to read.</param>
        /// <returns>A two-dimensional array containing tax rate data.</returns>
        private double[,] ReadTaxRateData(string fileName)
        {
            try
            {
                // Read all lines from the CSV file
                string[] lines = File.ReadAllLines(fileName);

                // Determine the number of rows and columns in the data
                int numRows = lines.Length;
                int numCols = lines[0].Split(',').Length;

                // Initialize the tax rate data array
                double[,] taxRateData = new double[numRows, numCols];

                // Populate the tax rate data array
                for (int i = 0; i < numRows; i++)
                {
                    string[] fields = lines[i].Split(',');

                    for (int j = 0; j < numCols; j++)
                    {
                        double.TryParse(fields[j], out taxRateData[i, j]);
                    }
                }

                return taxRateData;
            }
            catch (IOException ex)
            {
                // Handle IO exceptions that might occur while reading the file
                Console.WriteLine("Error reading tax rate data file: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                // Handle other exceptions that might occur while reading the file
                Console.WriteLine("An error occurred while reading tax rate data file: " + ex.Message);
                return null;
            }
        }
    }
}
