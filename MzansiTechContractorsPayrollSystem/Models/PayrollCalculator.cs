namespace MzansiTechContractorsPayrollSystem.Models
{
    public class PayrollCalculator
    {
        // Business constants - defined once to prevent magic numbers in code
        public const double HOURLY_RATE = 950.00;
        public const double UIF_RATE = 0.01;
        public const double PAYE_RATE = 0.25;
        public const double PAYE_DEPENDENT_ALLOWANCE = 0.0575;
        public const double MEMBERSHIP_RATE = 0.13;
        public const int MAX_DEPENDENTS = 10;

        // Object attributes/properties
        public string ContractorName { get; private set; }
        public double HoursWorked { get; private set; }
        public int Dependents { get; private set; }

        // Calculated results (populated after Calculate() is called)
        public double GrossPay       { get; private set; }
        public double UIFDeduction   { get; private set; }
        public double PAYEDeduction  { get; private set; }
        public double MembershipFee  { get; private set; }
        public double TotalDeductions { get; private set; }
        public double NetPay         { get; private set; }

        public PayrollCalculator(string contractorName, double hoursWorked, int dependents)
        {
            // Validates user input before processing the data
            if (string.IsNullOrWhiteSpace(contractorName))
                throw new ArgumentException("Contractor name cannot be empty.", nameof(contractorName));

            if (hoursWorked <= 0)
                throw new ArgumentOutOfRangeException(nameof(hoursWorked), "Hours worked must be greater than zero.");

            if (dependents < 0)
                throw new ArgumentOutOfRangeException(nameof(dependents), "Number of dependents cannot be negative.");

            if (dependents > MAX_DEPENDENTS)
                throw new ArgumentOutOfRangeException(nameof(dependents), $"Number of dependents cannot exceed {MAX_DEPENDENTS}.");

            ContractorName = contractorName;
            HoursWorked = hoursWorked;
            Dependents = dependents;
        }

        /* Calculates gross pay based on the contractors hours worked and the fixed hourly rate
         * Formula: (HoursWorked × HOURLY_RATE)
         */
        public double CalculateGrossPay()
        {
            return Math.Round(HoursWorked * HOURLY_RATE, 2);
        }

        /* Calculates UIF deduction at 1% based of the contractors gross pay
         * Formula: (GrossPay × 0.01)
         */
        public double CalculateUIF(double grossPay)
        {
            return Math.Round(grossPay * UIF_RATE, 2);
        }

        /*
         * Calculates PAYE deduction using the simplified SARS formula.
         * Formula: (GrossPay - (GrossPay × 0.0575 × Dependents)) × 25%
         * 
         */
        public double CalculatePAYE(double grossPay)
        {
            double taxableIncome = grossPay - (grossPay * PAYE_DEPENDENT_ALLOWANCE * Dependents);
            return Math.Round(taxableIncome * PAYE_RATE, 2);
        }

        /*
         * Calculates membership fee at 13% of gross pay.
         * Formula: (GrossPay × 0.13)
         */
        public double CalculateMembershipFee(double grossPay)
        {
            return Math.Round(grossPay * MEMBERSHIP_RATE, 2);
        }

        /*
         * Calculates the sum of the deductions based on the contractor
         * Formula: (UIF + PAYE + MembershipFee)
         */
        public double CalculateTotalDeductions(double UIFDeduction, double PAYEDeduction, double membershipFee)
        {
            return Math.Round(UIFDeduction + PAYEDeduction + membershipFee, 2);
        }

        /*
         * Calculates net pay for the contractor
         * Formula: (GrossPay - UIF - PAYE - MembershipFee )
         */
        public double CalculateNetPay(double grossPay, double totalDeductions)
        {
            return Math.Round(grossPay - totalDeductions, 2);
        }

        /*
         * Runs all payroll calculations and populates the result properties.
         * Call this method after constructing the object to obtain all values.
         */
        public void CalculateAllDeductions()
        {
            GrossPay        = CalculateGrossPay();
            UIFDeduction    = CalculateUIF(GrossPay);
            PAYEDeduction   = CalculatePAYE(GrossPay);
            MembershipFee   = CalculateMembershipFee(GrossPay);
            TotalDeductions = CalculateTotalDeductions(UIFDeduction, PAYEDeduction, MembershipFee);
            NetPay          = CalculateNetPay(GrossPay, TotalDeductions);
        }
    }
}
