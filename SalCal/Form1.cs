using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;

namespace SalCal
{
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
        public class EmployeeRecord
        {
            public string EmployeeID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string HourlyRate { get; set; }
            public string TaxThreshold { get; set; }
        }

        private void PopulateEmployeeListBox()
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
                    string taxThreshold = employeeDetails[4].Trim(); // this added


                    txtEmployeeID.Text = employeeID;
                    txtFirstName.Text = firstName;
                    txtLastName.Text = lastName;
                    txtHourlyRate.Text = hourlyRate.ToString();
                    TaxThreshold.Text = taxThreshold; // this added
                }
            }
        }

        private void btnCalculateTax_Click(object sender, EventArgs e)
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
                txtHourlyRate.Text = hourlyRate.ToString();
                TaxThreshold.Text = taxThreshold; // Added this last time
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


        //New Export with CVSHelper
        private void SavePaymentSummaryToCSV(string employeeID, string firstName, string lastName, double hoursWorked, double hourlyRate, string taxThreshold, double grossPay, double taxAmount, double netPay, double superannuation)
        {
            try
            {
                // Generate the CSV file name based on the naming convention
                string fileName = $"Pay-EmployeeID-{employeeID}-Fullname-{firstName}_{lastName}-{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv";

                using (var writer = new StreamWriter(fileName))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    // Write the payment summary data for the selected employee
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
                }

                MessageBox.Show($"Payment summary for Employee ID {employeeID} saved to {fileName}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                LogError("Error writing payment summary to CSV: " + ex.Message);
                MessageBox.Show("An error occurred while saving the payment summary. Please check the error log for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                LogError("An unexpected error occurred while saving the payment summary: " + ex.Message);
                MessageBox.Show("An unexpected error occurred while saving the payment summary. Please check the error log for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Old export code without CVSHelper
        //private void SavePaymentSummaryToCSV(string employeeID, string firstName, string lastName, double hoursWorked, double hourlyRate, string taxThreshold, double grossPay, double taxAmount, double netPay, double superannuation)
        //{
        //    try
        //    {
        //        // Generate the CSV file name based on the naming convention
        //        string fileName = $"Pay-EmployeeID-{employeeID}-Fullname-{firstName}_{lastName}-{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv";

        //        // Create the CSV file and write the payment summary data
        //        using (StreamWriter writer = new StreamWriter(fileName))
        //        {
        //            // Write the header row
        //            writer.WriteLine("EmployeeID,FirstName,LastName,HoursWorked,HourlyRate,TaxThreshold,GrossPay,Tax,NetPay,Superannuation"); //Removed TaxThreshold to fix cvs file

        //            // Write the payment summary data for the selected employee
        //            writer.WriteLine($"{employeeID},{firstName},{lastName},{hoursWorked},{hourlyRate},{taxThreshold},{grossPay},{taxAmount},{netPay},{superannuation}"); // include TaxThreshold?
        //        }

        //        MessageBox.Show($"Payment summary for Employee ID {employeeID} saved to {fileName}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (IOException ex)
        //    {
        //        LogError("Error writing payment summary to CSV: " + ex.Message);
        //        MessageBox.Show("An error occurred while saving the payment summary. Please check the error log for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError("An unexpected error occurred while saving the payment summary: " + ex.Message);
        //        MessageBox.Show("An unexpected error occurred while saving the payment summary. Please check the error log for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

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
                TaxThreshold.Text = taxThreshold; // Added this last time
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

        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}