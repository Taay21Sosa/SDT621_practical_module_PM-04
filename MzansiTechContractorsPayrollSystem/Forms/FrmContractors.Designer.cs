namespace MzansiTechContractorsPayrollSystem
{
    partial class FrmContractors
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
            lblTitle = new Label();
            lblContractName = new Label();
            lblHoursWorked = new Label();
            lblNumOfDepartments = new Label();
            txtName = new TextBox();
            txtDependents = new TextBox();
            txtHours = new TextBox();
            btnCalculateNetPay = new Button();
            btnReset = new Button();
            btnExit = new Button();
            lblGrossPay = new Label();
            txtGrossPay = new TextBox();
            lblPAYE = new Label();
            lblUIF = new Label();
            txtPAYE = new TextBox();
            txtUIF = new TextBox();
            txtMembership = new TextBox();
            txtTotalDeductions = new TextBox();
            txtNetPay = new TextBox();
            lblMembership = new Label();
            lblTotalDeductions = new Label();
            lblNetPay = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(208, 67);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(545, 62);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Manzi Tech Contractors";
            // 
            // lblContractName
            // 
            lblContractName.AutoSize = true;
            lblContractName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContractName.ForeColor = Color.White;
            lblContractName.Location = new Point(159, 236);
            lblContractName.Name = "lblContractName";
            lblContractName.Size = new Size(155, 28);
            lblContractName.TabIndex = 2;
            lblContractName.Text = "Contract Name";
            // 
            // lblHoursWorked
            // 
            lblHoursWorked.AutoSize = true;
            lblHoursWorked.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHoursWorked.ForeColor = Color.White;
            lblHoursWorked.Location = new Point(167, 298);
            lblHoursWorked.Name = "lblHoursWorked";
            lblHoursWorked.Size = new Size(147, 28);
            lblHoursWorked.TabIndex = 3;
            lblHoursWorked.Text = "Hours Worked";
            // 
            // lblNumOfDepartments
            // 
            lblNumOfDepartments.AutoSize = true;
            lblNumOfDepartments.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumOfDepartments.ForeColor = Color.White;
            lblNumOfDepartments.Location = new Point(95, 358);
            lblNumOfDepartments.Name = "lblNumOfDepartments";
            lblNumOfDepartments.Size = new Size(245, 28);
            lblNumOfDepartments.TabIndex = 5;
            lblNumOfDepartments.Text = "Number of Departments";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(395, 235);
            txtName.Name = "txtName";
            txtName.Size = new Size(300, 34);
            txtName.TabIndex = 6;
            // 
            // txtDependents
            // 
            txtDependents.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDependents.Location = new Point(395, 355);
            txtDependents.Name = "txtDependents";
            txtDependents.Size = new Size(300, 34);
            txtDependents.TabIndex = 7;
            // 
            // txtHours
            // 
            txtHours.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHours.Location = new Point(395, 295);
            txtHours.Name = "txtHours";
            txtHours.Size = new Size(300, 34);
            txtHours.TabIndex = 8;
            // 
            // btnCalculateNetPay
            // 
            btnCalculateNetPay.Location = new Point(138, 445);
            btnCalculateNetPay.Name = "btnCalculateNetPay";
            btnCalculateNetPay.Size = new Size(176, 45);
            btnCalculateNetPay.TabIndex = 9;
            btnCalculateNetPay.Text = "Calculate Net Pay";
            btnCalculateNetPay.UseVisualStyleBackColor = true;
            btnCalculateNetPay.Click += btnCalculateNetPay_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(361, 445);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(135, 45);
            btnReset.TabIndex = 10;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(551, 445);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(130, 45);
            btnExit.TabIndex = 11;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblGrossPay
            // 
            lblGrossPay.AutoSize = true;
            lblGrossPay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGrossPay.ForeColor = Color.White;
            lblGrossPay.Location = new Point(873, 233);
            lblGrossPay.Name = "lblGrossPay";
            lblGrossPay.Size = new Size(100, 28);
            lblGrossPay.TabIndex = 12;
            lblGrossPay.Text = "Gross Pay:";
            // 
            // txtGrossPay
            // 
            txtGrossPay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGrossPay.Location = new Point(1003, 230);
            txtGrossPay.Name = "txtGrossPay";
            txtGrossPay.Size = new Size(200, 34);
            txtGrossPay.TabIndex = 13;
            // 
            // lblPAYE
            // 
            lblPAYE.AutoSize = true;
            lblPAYE.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPAYE.ForeColor = Color.White;
            lblPAYE.Location = new Point(818, 283);
            lblPAYE.Name = "lblPAYE";
            lblPAYE.Size = new Size(155, 28);
            lblPAYE.TabIndex = 14;
            lblPAYE.Text = "PAYE Deduction:";
            // 
            // lblUIF
            // 
            lblUIF.AutoSize = true;
            lblUIF.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUIF.ForeColor = Color.White;
            lblUIF.Location = new Point(832, 333);
            lblUIF.Name = "lblUIF";
            lblUIF.Size = new Size(141, 28);
            lblUIF.TabIndex = 15;
            lblUIF.Text = "UIF Deduction:";
            // 
            // txtPAYE
            // 
            txtPAYE.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPAYE.Location = new Point(1003, 280);
            txtPAYE.Name = "txtPAYE";
            txtPAYE.Size = new Size(200, 34);
            txtPAYE.TabIndex = 16;
            // 
            // txtUIF
            // 
            txtUIF.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUIF.Location = new Point(1003, 330);
            txtUIF.Name = "txtUIF";
            txtUIF.Size = new Size(200, 34);
            txtUIF.TabIndex = 17;
            // 
            // txtMembership
            // 
            txtMembership.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMembership.Location = new Point(1003, 380);
            txtMembership.Name = "txtMembership";
            txtMembership.Size = new Size(200, 34);
            txtMembership.TabIndex = 18;
            // 
            // txtTotalDeductions
            // 
            txtTotalDeductions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotalDeductions.Location = new Point(1003, 430);
            txtTotalDeductions.Name = "txtTotalDeductions";
            txtTotalDeductions.Size = new Size(200, 34);
            txtTotalDeductions.TabIndex = 19;
            // 
            // txtNetPay
            // 
            txtNetPay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNetPay.Location = new Point(1003, 480);
            txtNetPay.Name = "txtNetPay";
            txtNetPay.Size = new Size(200, 34);
            txtNetPay.TabIndex = 20;
            // 
            // lblMembership
            // 
            lblMembership.AutoSize = true;
            lblMembership.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMembership.ForeColor = Color.White;
            lblMembership.Location = new Point(812, 386);
            lblMembership.Name = "lblMembership";
            lblMembership.Size = new Size(161, 28);
            lblMembership.TabIndex = 21;
            lblMembership.Text = "Membership Fee:";
            // 
            // lblTotalDeductions
            // 
            lblTotalDeductions.AutoSize = true;
            lblTotalDeductions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalDeductions.ForeColor = Color.White;
            lblTotalDeductions.Location = new Point(819, 433);
            lblTotalDeductions.Name = "lblTotalDeductions";
            lblTotalDeductions.Size = new Size(154, 28);
            lblTotalDeductions.TabIndex = 22;
            lblTotalDeductions.Text = "Total Deduction:";
            // 
            // lblNetPay
            // 
            lblNetPay.AutoSize = true;
            lblNetPay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNetPay.ForeColor = Color.White;
            lblNetPay.Location = new Point(890, 483);
            lblNetPay.Name = "lblNetPay";
            lblNetPay.Size = new Size(83, 28);
            lblNetPay.TabIndex = 23;
            lblNetPay.Text = "Net Pay:";
            // 
            // FrmContractorsPayroll
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(1318, 578);
            Controls.Add(lblNetPay);
            Controls.Add(lblTotalDeductions);
            Controls.Add(lblMembership);
            Controls.Add(txtNetPay);
            Controls.Add(txtTotalDeductions);
            Controls.Add(txtMembership);
            Controls.Add(txtUIF);
            Controls.Add(txtPAYE);
            Controls.Add(lblUIF);
            Controls.Add(lblPAYE);
            Controls.Add(txtGrossPay);
            Controls.Add(lblGrossPay);
            Controls.Add(btnExit);
            Controls.Add(btnReset);
            Controls.Add(btnCalculateNetPay);
            Controls.Add(txtDependents);
            Controls.Add(txtHours);
            Controls.Add(txtName);
            Controls.Add(lblNumOfDepartments);
            Controls.Add(lblHoursWorked);
            Controls.Add(lblContractName);
            Controls.Add(lblTitle);
            Name = "FrmContractorsPayroll";
            Text = "Mzansi Tech Contractors Payroll System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblContractName;
        private Label lblHoursWorked;
        private Label lblNumOfDepartments;
        private TextBox txtName;
        private TextBox txtHours;
        private TextBox txtDependents;
        private Button btnCalculateNetPay;
        private Button btnReset;
        private Button btnExit;
        private Label lblGrossPay;
        private TextBox txtGrossPay;
        private Label lblPAYE;
        private Label lblUIF;
        private TextBox txtPAYE;
        private TextBox txtUIF;
        private TextBox txtMembership;
        private TextBox txtTotalDeductions;
        private TextBox txtNetPay;
        private Label lblMembership;
        private Label lblTotalDeductions;
        private Label lblNetPay;
    }
}
