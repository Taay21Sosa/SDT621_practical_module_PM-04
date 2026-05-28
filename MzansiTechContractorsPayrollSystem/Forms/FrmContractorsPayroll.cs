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
