namespace SalCal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSave = new Button();
            btnCalculateTax = new Button();
            txtSuperannuation = new TextBox();
            txtNetPay = new TextBox();
            txtTax = new TextBox();
            txtGrossPay = new TextBox();
            TaxThreshold = new TextBox();
            txtHourlyRate = new TextBox();
            txtHoursWorked = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            txtEmployeeID = new TextBox();
            panel3 = new Panel();
            label22 = new Label();
            label23 = new Label();
            label15 = new Label();
            label2 = new Label();
            employeeListBox = new ListBox();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            EmployeeID = new Label();
            panel1 = new Panel();
            X = new Button();
            label1 = new Label();
            label6 = new Label();
            panel2 = new Panel();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.WhiteSmoke;
            btnSave.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.ForeColor = Color.DarkViolet;
            btnSave.Location = new Point(999, 301);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(178, 126);
            btnSave.TabIndex = 8;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click_1;
            // 
            // btnCalculateTax
            // 
            btnCalculateTax.BackColor = Color.DarkViolet;
            btnCalculateTax.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnCalculateTax.ForeColor = Color.White;
            btnCalculateTax.Location = new Point(699, 301);
            btnCalculateTax.Name = "btnCalculateTax";
            btnCalculateTax.Size = new Size(214, 126);
            btnCalculateTax.TabIndex = 7;
            btnCalculateTax.Text = "CALCULATE TAX";
            btnCalculateTax.UseVisualStyleBackColor = false;
            btnCalculateTax.Click += btnCalculateTax_Click;
            // 
            // txtSuperannuation
            // 
            txtSuperannuation.Location = new Point(122, 518);
            txtSuperannuation.Name = "txtSuperannuation";
            txtSuperannuation.Size = new Size(258, 23);
            txtSuperannuation.TabIndex = 25;
            // 
            // txtNetPay
            // 
            txtNetPay.Location = new Point(122, 485);
            txtNetPay.Name = "txtNetPay";
            txtNetPay.Size = new Size(258, 23);
            txtNetPay.TabIndex = 24;
            // 
            // txtTax
            // 
            txtTax.Location = new Point(122, 448);
            txtTax.Name = "txtTax";
            txtTax.Size = new Size(258, 23);
            txtTax.TabIndex = 23;
            // 
            // txtGrossPay
            // 
            txtGrossPay.Location = new Point(122, 413);
            txtGrossPay.Name = "txtGrossPay";
            txtGrossPay.Size = new Size(258, 23);
            txtGrossPay.TabIndex = 22;
            // 
            // TaxThreshold
            // 
            TaxThreshold.Location = new Point(122, 375);
            TaxThreshold.Name = "TaxThreshold";
            TaxThreshold.Size = new Size(258, 23);
            TaxThreshold.TabIndex = 21;
            // 
            // txtHourlyRate
            // 
            txtHourlyRate.Location = new Point(122, 332);
            txtHourlyRate.Name = "txtHourlyRate";
            txtHourlyRate.Size = new Size(258, 23);
            txtHourlyRate.TabIndex = 20;
            // 
            // txtHoursWorked
            // 
            txtHoursWorked.Location = new Point(122, 290);
            txtHoursWorked.Name = "txtHoursWorked";
            txtHoursWorked.Size = new Size(258, 23);
            txtHoursWorked.TabIndex = 19;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(122, 110);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(258, 23);
            txtLastName.TabIndex = 18;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(122, 69);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(258, 23);
            txtFirstName.TabIndex = 17;
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Location = new Point(122, 29);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.Size = new Size(258, 23);
            txtEmployeeID.TabIndex = 16;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkViolet;
            panel3.Controls.Add(label22);
            panel3.Controls.Add(label23);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(txtSuperannuation);
            panel3.Controls.Add(txtNetPay);
            panel3.Controls.Add(txtTax);
            panel3.Controls.Add(txtGrossPay);
            panel3.Controls.Add(TaxThreshold);
            panel3.Controls.Add(txtHourlyRate);
            panel3.Controls.Add(txtHoursWorked);
            panel3.Controls.Add(txtLastName);
            panel3.Controls.Add(txtFirstName);
            panel3.Controls.Add(txtEmployeeID);
            panel3.Controls.Add(employeeListBox);
            panel3.Controls.Add(label14);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(EmployeeID);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 100);
            panel3.Name = "panel3";
            panel3.Size = new Size(562, 541);
            panel3.TabIndex = 5;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Showcard Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label22.ForeColor = Color.WhiteSmoke;
            label22.Location = new Point(444, 139);
            label22.Name = "label22";
            label22.Size = new Size(48, 17);
            label22.TabIndex = 29;
            label22.Text = "Step 1";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Showcard Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label23.ForeColor = Color.WhiteSmoke;
            label23.Location = new Point(360, 156);
            label23.Name = "label23";
            label23.Size = new Size(194, 17);
            label23.TabIndex = 28;
            label23.Text = "Select employee from list";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Showcard Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label15.ForeColor = Color.WhiteSmoke;
            label15.Location = new Point(443, 275);
            label15.Name = "label15";
            label15.Size = new Size(49, 17);
            label15.TabIndex = 27;
            label15.Text = "Step 2";
            label15.Click += label15_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(393, 292);
            label2.Name = "label2";
            label2.Size = new Size(161, 17);
            label2.TabIndex = 26;
            label2.Text = "Input Hours Worked";
            label2.Click += label2_Click;
            // 
            // employeeListBox
            // 
            employeeListBox.FormattingEnabled = true;
            employeeListBox.ItemHeight = 15;
            employeeListBox.Location = new Point(25, 176);
            employeeListBox.Name = "employeeListBox";
            employeeListBox.Size = new Size(503, 49);
            employeeListBox.TabIndex = 15;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(25, 519);
            label14.Name = "label14";
            label14.Size = new Size(94, 15);
            label14.TabIndex = 14;
            label14.Text = "Superannuation:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(25, 485);
            label13.Name = "label13";
            label13.Size = new Size(51, 15);
            label13.TabIndex = 13;
            label13.Text = "Net Pay:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(25, 451);
            label12.Name = "label12";
            label12.Size = new Size(27, 15);
            label12.TabIndex = 12;
            label12.Text = "Tax:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(25, 416);
            label11.Name = "label11";
            label11.Size = new Size(61, 15);
            label11.TabIndex = 11;
            label11.Text = "Gross Pay:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(25, 381);
            label10.Name = "label10";
            label10.Size = new Size(82, 15);
            label10.TabIndex = 10;
            label10.Text = "Tax Threshold:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(25, 337);
            label9.Name = "label9";
            label9.Size = new Size(75, 15);
            label9.TabIndex = 9;
            label9.Text = "Hourly Rate: ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 296);
            label8.Name = "label8";
            label8.Size = new Size(86, 15);
            label8.TabIndex = 8;
            label8.Text = "Hours Worked:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 147);
            label7.Name = "label7";
            label7.Size = new Size(83, 15);
            label7.TabIndex = 7;
            label7.Text = "Employee List:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.WhiteSmoke;
            label5.Location = new Point(167, 255);
            label5.Name = "label5";
            label5.Size = new Size(194, 23);
            label5.TabIndex = 6;
            label5.Text = "Payment Summary";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 110);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 5;
            label4.Text = "Last Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 72);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 4;
            label3.Text = "First Name:";
            // 
            // EmployeeID
            // 
            EmployeeID.AutoSize = true;
            EmployeeID.Location = new Point(20, 37);
            EmployeeID.Name = "EmployeeID";
            EmployeeID.Size = new Size(76, 15);
            EmployeeID.TabIndex = 3;
            EmployeeID.Text = "Employee ID:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkViolet;
            panel1.Controls.Add(X);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label6);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1269, 100);
            panel1.TabIndex = 4;
            // 
            // X
            // 
            X.BackColor = Color.WhiteSmoke;
            X.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            X.ForeColor = Color.DarkViolet;
            X.Location = new Point(1222, 3);
            X.Name = "X";
            X.Size = new Size(44, 37);
            X.TabIndex = 9;
            X.Text = " X";
            X.UseVisualStyleBackColor = false;
            X.Click += X_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(463, 31);
            label1.Name = "label1";
            label1.Size = new Size(309, 36);
            label1.TabIndex = 2;
            label1.Text = "Salary Calculator";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.WhiteSmoke;
            label6.Location = new Point(172, 77);
            label6.Name = "label6";
            label6.Size = new Size(189, 23);
            label6.TabIndex = 3;
            label6.Text = "Employee Details";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkViolet;
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 641);
            panel2.Name = "panel2";
            panel2.Size = new Size(1269, 32);
            panel2.TabIndex = 6;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Showcard Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label16.ForeColor = Color.DarkViolet;
            label16.Location = new Point(780, 438);
            label16.Name = "label16";
            label16.Size = new Size(49, 17);
            label16.TabIndex = 29;
            label16.Text = "Step 3";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Showcard Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label17.ForeColor = Color.DarkViolet;
            label17.Location = new Point(711, 455);
            label17.Name = "label17";
            label17.Size = new Size(211, 17);
            label17.TabIndex = 28;
            label17.Text = "Press Calculate Tax Button";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Showcard Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label18.ForeColor = Color.DarkViolet;
            label18.Location = new Point(1064, 438);
            label18.Name = "label18";
            label18.Size = new Size(50, 17);
            label18.TabIndex = 31;
            label18.Text = "Step 4";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Showcard Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label19.ForeColor = Color.DarkViolet;
            label19.Location = new Point(1020, 455);
            label19.Name = "label19";
            label19.Size = new Size(139, 17);
            label19.TabIndex = 30;
            label19.Text = "Press Save Button";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Showcard Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label20.ForeColor = Color.DarkViolet;
            label20.Location = new Point(994, 475);
            label20.Name = "label20";
            label20.Size = new Size(193, 17);
            label20.TabIndex = 32;
            label20.Text = "To save Payment Summary";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Showcard Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label21.ForeColor = Color.DarkViolet;
            label21.Location = new Point(699, 472);
            label21.Name = "label21";
            label21.Size = new Size(228, 17);
            label21.TabIndex = 33;
            label21.Text = "To generate Payment Summary";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1269, 673);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(label18);
            Controls.Add(label19);
            Controls.Add(label16);
            Controls.Add(label17);
            Controls.Add(btnSave);
            Controls.Add(btnCalculateTax);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel3;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label EmployeeID;
        private Panel panel1;
        private Label label1;
        private Label label6;
        private Panel panel2;
        private Button X;
        private Label label2;
        public ListBox employeeListBox;
        public TextBox txtSuperannuation;
        public TextBox txtNetPay;
        public TextBox txtTax;
        public TextBox txtGrossPay;
        public TextBox TaxThreshold;
        public TextBox txtHourlyRate;
        public TextBox txtHoursWorked;
        public TextBox txtLastName;
        public TextBox txtFirstName;
        public TextBox txtEmployeeID;
        public Button btnSave;
        public Button btnCalculateTax;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
    }
}