using SalCal;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1() // Test UI to Load employee.csv to EmployeeListBox
        {
            // Arrange: Set up any necessary conditions for testing
            var form = new Form1(); // Create an instance of the form containing PopulateEmployeeListBox.

            // Act: Call the method to be tested.
            form.PopulateEmployeeListBox();

            // Assert: Check if the ListBox contains the expected items.
            // Replace the following with your specific assertions based on your test data.
            Assert.AreEqual(7, form.employeeListBox.Items.Count); // Example assertion.
        }

        [TestMethod]
        public void TestMethod2() //Test Methods
        {
            // Arrange
            var form = new Form1();
            form.txtEmployeeID.Text = "1";
            form.txtFirstName.Text = "Marge";
            form.txtLastName.Text = "Larkin";
            form.txtHourlyRate.Text = "25"; // Set the hourly rate
            form.txtHoursWorked.Text = "40"; // Set the hours worked
            form.TaxThreshold.Text = "Y";

            PayCalculator payCalculator = new PayCalculator();

            // Simulate adding an item to the employeeListBox and selecting it
            string employeeDetail = "1, Marge, Larkin, 25, Y";
            form.employeeListBox.Items.Add(employeeDetail);
            form.employeeListBox.SelectedIndex = 0;

            // Act
            form.btnCalculateTax_Click(null, null);

            // Assert
            // Calculate the expected values based on the provided input
            double expectedGrossPay = 25 * 40; // Assuming hourly rate * hours worked
            double expectedTax = payCalculator.CalculateTax(expectedGrossPay, "Y");
            double expectedNetPay = expectedGrossPay - expectedTax;
            double expectedSuperannuation = expectedGrossPay * 0.11; // Assuming superannuation rate of 11%

            // Compare to predefined numbers
            double predefinedGrossPay = 1000.0; 
            double predefinedTax = 161.83232299999997; 
            double predefinedNetPay = 838.167677;
            double predefinedSuperannuation = 110.0; 

            Assert.AreEqual(predefinedGrossPay, expectedGrossPay);
            Assert.AreEqual(predefinedTax, expectedTax);
            Assert.AreEqual(predefinedNetPay, expectedNetPay);
            Assert.AreEqual(predefinedSuperannuation, expectedSuperannuation);
        }


        //[TestMethod] //Test Methods
        //public void TestMethod2()
        //{
        //    // Arrange
        //    var form = new Form1();
        //    form.txtEmployeeID.Text = "1";
        //    form.txtFirstName.Text = "Marge";
        //    form.txtLastName.Text = "Larkin";
        //    form.txtHourlyRate.Text = "25"; // Set the hourly rate
        //    form.txtHoursWorked.Text = "40"; // Set the hours worked
        //    form.TaxThreshold.Text = "Y";

        //    PayCalculator payCalculator = new PayCalculator();

        //    // Simulate adding an item to the employeeListBox and selecting it
        //    string employeeDetail = "1, Marge, Larkin, 25, Y";
        //    form.employeeListBox.Items.Add(employeeDetail);
        //    form.employeeListBox.SelectedIndex = 0;

        //    // Act
        //    form.btnCalculateTax_Click(null, null);

        //    // Assert
        //    // Calculate the expected values based on the provided input
        //    double expectedGrossPay = 25 * 40; // Assuming hourly rate * hours worked
        //    double expectedTax = payCalculator.CalculateTax(expectedGrossPay, "Y"); 
        //    double expectedNetPay = expectedGrossPay - expectedTax;
        //    double expectedSuperannuation = expectedGrossPay * 0.11; // Assuming superannuation rate of 11%

        //    Assert.AreEqual(expectedGrossPay.ToString(), form.txtGrossPay.Text);
        //    Assert.AreEqual(expectedTax.ToString(), form.txtTax.Text);
        //    Assert.AreEqual(expectedNetPay.ToString(), form.txtNetPay.Text);
        //    Assert.AreEqual(expectedSuperannuation.ToString(), form.txtSuperannuation.Text);
        //}


        //[TestMethod]
        //public void TestMethod2() //Test Methods
        //{
        //    // Arrange: Set up the test scenario with sample data, such as a mock employeeListBox and input textboxes.
        //    var form = new Form1();
        //    form.txtEmployeeID.Text = "111";
        //    form.txtFirstName.Text = "Matt";
        //    form.txtLastName.Text = "Woodward";
        //    form.txtHourlyRate.Text = "25";
        //    form.txtHourlyRate.Text = "25";
        //    form.TaxThreshold.Text = "Y"; 

        //    form.btnCalculateTax_Click(null, null); // Simulate button click.

        //    // Assert: Check if the text in the output textboxes matches the expected results.
        //    Assert.AreEqual("625", form.txtGrossPay.Text);
        //    Assert.AreEqual("199.5965", form.txtTax.Text); // Example assertion for gross pay.
        //    Assert.AreEqual("425.4035", form.txtNetPay.Text);
        //    Assert.AreEqual("68.75", form.txtSuperannuation.Text);
        //}

        [TestMethod]
        public void TestMethod3() // Test use-components export to SavePaymentSummaryToCSV
        {
            // Arrange - Set up the test data and environment
            string employeeID = "123";
            string firstName = "John";
            string lastName = "Doe";
            double hoursWorked = 40.0;
            double hourlyRate = 20.0;
            string taxThreshold = "Y";
            double grossPay = 800.0;
            double taxAmount = 160.0;
            double netPay = 640.0;
            double superannuation = 88.0;

            Form1 instance = new Form1();

            
            // Act - Call the method to be tested
            string fileName = instance.SavePaymentSummaryToCSV(employeeID, firstName, lastName, hoursWorked, hourlyRate, taxThreshold, grossPay, taxAmount, netPay, superannuation);

            // Assert: Check the result or the output
            // 1. Check if the file was created
            bool fileExists = File.Exists(fileName);
            Assert.IsTrue(fileExists, $"The file {fileName} should have been created.");

            // 2. Assert the filename starts with the expected prefix
            Assert.IsTrue(fileName.StartsWith(fileName), "The filename should start with the expected prefix.");

            // 3. Read the file and verify its content
            if (fileExists)
            {
                string fileContent = File.ReadAllText(fileName);
                Assert.IsTrue(fileContent.Contains(employeeID), "Employee ID should be in the file content.");
                Assert.IsTrue(fileContent.Contains(firstName), "First Name should be in the file content.");
                
            }
        }

    }
}