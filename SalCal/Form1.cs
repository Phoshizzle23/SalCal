using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;

namespace SalCal
{
    /// <summary>
    /// Represents the main form of the Salary Calculator application.
    /// </summary>
    public partial class Form1 : Form
    {
        private PayCalculator payCalculator;

        public Form1()
        {
            InitializeComponent();

            // Create an instance of PayCalculator
            payCalculator = new PayCalculator();

            // Call the method to populate the ListBox with employee details
            PopulateEmployeeListBox();
        }

        /// <summary>
        /// Represents a data structure for storing employee details.
        /// </summary>
        public class EmployeeRecord
        {
            public string EmployeeID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string HourlyRate { get; set; }
            public string TaxThreshold { get; set; }
        }

        /// <summary>
        /// Populates the ListBox control with employee details read from a CSV file.
        /// </summary>
        public void PopulateEmployeeListBox()
        {
            string csvFilePath = "employee.csv";

            try
            {
                var employeeDetailsList = new List<EmployeeRecord>();

                using (var reader = new StreamReader(csvFilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    while (csv.Read())
                    {
                        var record = csv.GetRecord<EmployeeRecord>();
                        if (record != null)
                        {
                            employeeDetailsList.Add(record);
                        }
                    }
                }

                // Clear the ListBox if there are existing items
                employeeListBox.Items.Clear();

                // Populate the ListBox with employee details
                foreach (var employee in employeeDetailsList)
                {
                    // Format employee details as a string
                    string employeeDetail = $"{employee.EmployeeID}, {employee.FirstName}, {employee.LastName}, {employee.HourlyRate}, {employee.TaxThreshold}";
                    employeeListBox.Items.Add(employeeDetail);
                }
            }
            catch (IOException ex)
            {
                LogError("Error reading employee.csv: " + ex.Message);
                MessageBox.Show("An error occurred while reading employee.csv. Please check the error log for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                LogError("An unexpected error occurred while reading employee.csv: " + ex.Message);
                MessageBox.Show("An unexpected error occurred while reading employee.csv. Please check the error log for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Logs an error message to an error log file.
        /// </summary>
        /// <param name="errorMessage">The error message to be logged.</param>
        private void LogError(string errorMessage)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("GE_Error-Log.txt", true))
                {
                    string logEntry = $"{DateTime.Now} - {errorMessage}";
                    writer.WriteLine(logEntry);
                }
            }
            catch (Exception ex)
            {
                string logErrorMessage = $"Error while writing to error log: {ex.Message}";
                MessageBox.Show(logErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the selection change of the employeeListBox.
        /// Updates the displayed employee details when a different employee is selected.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An instance of the <see cref="EventArgs"/> class.</param>
        private void employeeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // The code below is for handling the selection change of the employeeListBox.
            // This event will be triggered when the user selects a different employee from the list.

            if (employeeListBox.SelectedIndex >= 0)
            {
                string selectedEmployee = employeeListBox.SelectedItem.ToString();
                string[] employeeDetails = selectedEmployee.Split(',');

                if (employeeDetails.Length >= 5) // Updated this
                {
                    string employeeID = employeeDetails[0].Trim();
                    string firstName = employeeDetails[1].Trim();
                    string lastName = employeeDetails[2].Trim();
                    double hourlyRate = Double.Parse(employeeDetails[3].Trim());
                    string taxThreshold = employeeDetails[4].Trim();


                    txtEmployeeID.Text = employeeID;
                    txtFirstName.Text = firstName;
                    txtLastName.Text = lastName;
                    txtHourlyRate.Text = hourlyRate.ToString();
                    TaxThreshold.Text = taxThreshold; 
                }
            }
        }

        /// <summary>
        /// Handles the "Calculate Tax" button click event.
        /// Calculates tax and displays payment summary for the selected employee.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An instance of the <see cref="EventArgs"/> class.</param>
        public void btnCalculateTax_Click(object sender, EventArgs e)
        {
            if (employeeListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an employee from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the selected employee details from the selected item in the employeeListBox
            string selectedEmployee = employeeListBox.SelectedItem.ToString();
            string[] employeeDetails = selectedEmployee.Split(',');

            if (employeeDetails.Length >= 5) // this changed from 3
            {
                // Extract the employee ID, first name, and last name from the selected item
                string employeeID = employeeDetails[0].Trim();
                string firstName = employeeDetails[1].Trim();
                string lastName = employeeDetails[2].Trim();
                double hourlyRate = Double.Parse(employeeDetails[3].Trim());
                string taxThreshold = employeeDetails[4].Trim(); // this added

                // Input the hours worked and hourly rate from the user
                double hoursWorked;
                //double hourlyRate;

                if (!double.TryParse(txtHoursWorked.Text, out hoursWorked)) /*|| !double.TryParse(txtHourlyRate.Text, out hourlyRate))*/
                {
                    MessageBox.Show("Invalid input for hours worked.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string taxRateMethod = taxThreshold; 

                // Calculate the payment summary using the PayCalculator class
                double grossPay = payCalculator.CalculateGrossPay(hoursWorked, hourlyRate);
                double taxAmount = payCalculator.CalculateTax(grossPay, taxRateMethod);
                double netPay = payCalculator.CalculateNetPay(grossPay, taxAmount);

                // Current superannuation rate (as from 1 July 2023)
                double superannuationRate = 0.11;
                double superannuation = payCalculator.CalculateSuperannuation(grossPay, superannuationRate);

                // Display the payment summary information in the respective textboxes
                txtEmployeeID.Text = employeeID;
                txtFirstName.Text = firstName;
                txtLastName.Text = lastName;
                txtHourlyRate.Text = hourlyRate.ToString();
                TaxThreshold.Text = taxThreshold; 
                txtGrossPay.Text = grossPay.ToString();
                txtTax.Text = taxAmount.ToString();
                txtNetPay.Text = netPay.ToString();
                txtSuperannuation.Text = superannuation.ToString();

            }
            else
            {
                // In case there is an issue with the selected employee details, display an error message
                MessageBox.Show("Invalid format for employee details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //Code Export with CVSHelper
        public string SavePaymentSummaryToCSV(string employeeID, string firstName, string lastName, double hoursWorked, double hourlyRate, string taxThreshold, double grossPay, double taxAmount, double netPay, double superannuation)
        {
            /// <summary>
            /// Generates a unique CSV filename for saving the payment summary.
            /// </summary>
            /// <param name="employeeID">The employee's ID.</param>
            /// <param name="firstName">The employee's first name.</param>
            /// <param name="lastName">The employee's last name.</param>
            /// <returns>The generated CSV filename.</returns>
            string fileName = GenerateFileName(employeeID, firstName, lastName);

            try
            {
                using (var writer = new StreamWriter(fileName))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecord(new
                    {
                        EmployeeID = employeeID,
                        FirstName = firstName,
                        LastName = lastName,
                        HoursWorked = hoursWorked,
                        HourlyRate = hourlyRate,
                        TaxThreshold = taxThreshold,
                        GrossPay = grossPay,
                        Tax = taxAmount,
                        NetPay = netPay,
                        Superannuation = superannuation
                    });

                    MessageBox.Show($"Payment summary for Employee ID {employeeID} saved to {fileName}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return fileName; // Return the filename for testing
            }
            catch (IOException ex)
            {
                LogError("Error writing payment summary to CSV: " + ex.Message);
                return null; // Indicate failure
            }
            catch (Exception ex)
            {
                LogError("An unexpected error occurred while saving the payment summary: " + ex.Message);
                return null; // Indicate failure
            }
        }

        private string GenerateFileName(string employeeID, string firstName, string lastName)
        {
            return $"Pay-EmployeeID-{employeeID}-Fullname-{firstName}_{lastName}-{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv";
        }

        /// <summary>
        /// Handles the "Save" button click event.
        /// Saves the payment summary to a CSV file.
        /// </summary>
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (employeeListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an employee from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the selected employee details from the selected item in the employeeListBox
            string selectedEmployee = employeeListBox.SelectedItem.ToString();
            string[] employeeDetails = selectedEmployee.Split(',');

            if (employeeDetails.Length >= 5) // this changed from 3
            {
                // Extract the employee ID, first name, and last name from the selected item
                string employeeID = employeeDetails[0].Trim();
                string firstName = employeeDetails[1].Trim();
                string lastName = employeeDetails[2].Trim();
                string taxThreshold = employeeDetails[4].Trim(); // this added

                // Input the hours worked and hourly rate from the user
                double hoursWorked;
                double hourlyRate;

                if (!double.TryParse(txtHoursWorked.Text, out hoursWorked) || !double.TryParse(txtHourlyRate.Text, out hourlyRate))
                {
                    MessageBox.Show("Invalid input for hours worked or hourly rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string taxRateMethod = taxThreshold; // this changed from string taxRateMethod = "Y"

                // Calculate the payment summary using the PayCalculator class
                double grossPay = payCalculator.CalculateGrossPay(hoursWorked, hourlyRate);
                double taxAmount = payCalculator.CalculateTax(grossPay, taxRateMethod);
                double netPay = payCalculator.CalculateNetPay(grossPay, taxAmount);

                // Current superannuation rate (as from 1 July 2023)
                double superannuationRate = 0.11;
                double superannuation = payCalculator.CalculateSuperannuation(grossPay, superannuationRate);

                // Display the payment summary information in the respective textboxes
                txtEmployeeID.Text = employeeID;
                txtFirstName.Text = firstName;
                txtLastName.Text = lastName;
                TaxThreshold.Text = taxThreshold; 
                txtGrossPay.Text = grossPay.ToString();
                txtTax.Text = taxAmount.ToString();
                txtNetPay.Text = netPay.ToString();
                txtSuperannuation.Text = superannuation.ToString();

                // Save the payment summary to a CSV file
                SavePaymentSummaryToCSV(employeeID, firstName, lastName, hoursWorked, hourlyRate, taxThreshold, grossPay, taxAmount, netPay, superannuation);
            }
            else
            {
                // In case there is an issue with the selected employee details, display an error message
                MessageBox.Show("Invalid format for employee details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Closes the application when the close button is clicked.
        /// </summary>
        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}