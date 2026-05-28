using MzansiTechContractorsPayrollSystem.Models;

namespace MzansiTechContractorsPayrollSystem
{
    public partial class FrmContractorsPayroll : Form
    {
        public FrmContractorsPayroll()
        {
            InitializeComponent();
        }

        private void btnCalculateNetPay_Click(object sender, EventArgs e)
        {
            //ResetForm();

            string contractorName = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(contractorName))
            {
                ShowError("Contractor name cannot be empty.");
                txtName.Focus();
                return;
            }

            if (!double.TryParse(txtHours.Text.Trim(), out double hoursWorked))
            {
                ShowError("Hours worked must be a valid number.");
                txtHours.Focus();
                return;
            }

            if (hoursWorked <= 0)
            {
                ShowError("Hours worked must be greater than zero.");
                txtHours.Focus();
                return;
            }

            if (!int.TryParse(txtDependents.Text.Trim(), out int dependents))
            {
                ShowError("Number of dependents must be a whole number.");
                txtDependents.Focus();
                return;
            }

            if (dependents < 0)
            {
                ShowError("Number of dependents cannot be negative.");
                txtDependents.Focus();
                return;
            }

            if (dependents > Contractor.MAX_DEPENDENTS)
            {
                ShowError($"Number of dependents cannot exceed {Contractor.MAX_DEPENDENTS}.");
                txtDependents.Focus();
                return;
            }

            CalculateContractorsData(contractorName, hoursWorked, dependents);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
            txtName.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalculateContractorsData(string contractorName, double hoursWorked, int dependents)
        {
            try
            {
                var _contractor = new Contractor(contractorName, hoursWorked, dependents);

                // Performs the calculations for the contractor
                double grossPay        = _contractor.CalculateGrossPay();
                double PAYEDeduction   = _contractor.CalculatePAYE(grossPay);
                double UIFDeduction    = _contractor.CalculateUIF(grossPay);
                double membershipFee   = _contractor.CalculateMembershipFee(grossPay);
                double totalDeductions = _contractor.CalculateTotalDeductions(UIFDeduction, PAYEDeduction, membershipFee);
                double NetPay          = _contractor.CalculateNetPay(grossPay, totalDeductions);

                // Displays the results
                txtGrossPay.Text        = $"{grossPay}";
                txtPAYE.Text            = $"{PAYEDeduction}";
                txtUIF.Text             = $"{UIFDeduction}";
                txtMembership.Text      = $"{membershipFee}";
                txtTotalDeductions.Text = $"{totalDeductions}";
                txtNetPay.Text          = $"{NetPay}";
            }
            catch (Exception ex)
            {
                ShowError($"An error occurred while creating new contractor:\n{ex.Message}");
            }
        }

        private static void ShowError(string message)
        {
            MessageBox.Show(message, "Input Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ResetForm()
        {
            txtName.Clear();
            txtHours.Clear();
            txtDependents.Clear();
            txtGrossPay.Clear();
            txtPAYE.Clear();
            txtUIF.Clear();
            txtMembership.Clear();
            txtTotalDeductions.Clear();
            txtNetPay.Clear();
        }
    }
}
