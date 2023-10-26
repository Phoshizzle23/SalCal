using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csv;

namespace SalCal
{
    class PaySlip
    {
        public double[,] TaxRatesWithThresholds { get; private set; }
        public double[,] TaxRatesWithoutThresholds { get; private set; }

        public PaySlip()
        {
            // Call methods to read tax rate data files and populate the class
            PopulateTaxRatesWithThresholds();
            PopulateTaxRatesWithoutThresholds();
        }

        private void PopulateTaxRatesWithThresholds()
        {
            string taxRateDataFile = "taxrate-withthreshold.csv";
            TaxRatesWithThresholds = ReadTaxRateData(taxRateDataFile);
        }

        private void PopulateTaxRatesWithoutThresholds()
        {
            string taxRateDataFile = "taxrate-nothreshold.csv";
            TaxRatesWithoutThresholds = ReadTaxRateData(taxRateDataFile);
        }

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
