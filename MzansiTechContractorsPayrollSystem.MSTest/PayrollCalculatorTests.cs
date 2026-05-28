using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.Contracts;
using MzansiTechContractorsPayrollSystem.Models;

namespace MzansiTechContractorsPayrollSystem.MSTest
{
    [TestClass]
    public sealed class PayrollCalculatorTests
    {
        // TestContext property MUST be public for MSTest to inject the execution context
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestSetup()
        {
            TestContext.WriteLine($"[SETUP] Starting test: {TestContext.TestName}");
            // Add your test setup/initialization code here
        }

        [TestCleanup]
        public void TestTeardown()
        {
            // Fetch the status of the test that just finished
            string testStatus = TestContext.CurrentTestOutcome.ToString();
            
            TestContext.WriteLine($"[TEARDOWN] Completed test '{TestContext.TestName}' with status: {testStatus}");
            TestContext.WriteLine("--------------------------------------------------");
        }

        // <----- UNIT TESTS — Gross Pay ----->
        [TestMethod]
        [TestCategory("Unit - GrossPay")]
        public void GrossPay_40Hours_ReturnsCorrectValue()
        {
            // Arrange: 40 hours × R950 = R38,000
            var calc = new PayrollCalculator("John Smith", 40, 0);
            // Act
            double result = calc.CalculateGrossPay();
            // Assert
            Assert.AreEqual(38000.00, result, 0.01,
                "Gross pay for 40 hours should be R38,000.00");
        }

        [TestMethod]
        [TestCategory("Unit - GrossPay")]
        public void GrossPay_160Hours_ReturnsCorrectValue()
        {
            // Arrange: 160 hours × R950 = R152,000
            var calc = new PayrollCalculator("Jane Doe", 160, 2);
            double result = calc.CalculateGrossPay();
            Assert.AreEqual(152000.00, result, 0.01,
                "Gross pay for 160 hours should be R152,000.00");
        }

        [TestMethod]
        [TestCategory("Unit - GrossPay")]
        public void GrossPay_1Hour_ReturnsHourlyRate()
        {
            // Minimum valid case: 1 hour
            var calc = new PayrollCalculator("Test User", 1, 0);
            double result = calc.CalculateGrossPay();
            Assert.AreEqual(950.00, result, 0.01,
                "Gross pay for 1 hour should equal the hourly rate R950.00");
        }

        // <----- UNIT TESTS — UIF Deduction ----->
        [TestMethod]
        [TestCategory("Unit - UIF")]
        public void UIF_GrossPay38000_Returns380()
        {
            // UIF = 38000 × 0.01 = R380.00
            var calc   = new PayrollCalculator("John Smith", 40, 0);
            double uif = calc.CalculateUIF(38000.00);
            Assert.AreEqual(380.00, uif, 0.01,
                "UIF on R38,000 gross pay should be R380.00");
        }

        [TestMethod]
        [TestCategory("Unit - UIF")]
        public void UIF_GrossPay152000_Returns1520()
        {
            // UIF = 152000 × 0.01 = R1,520.00
            var calc = new PayrollCalculator("Jane Doe", 160, 0);
            double uif = calc.CalculateUIF(152000.00);
            Assert.AreEqual(1520.00, uif, 0.01,
                "UIF on R152,000 gross pay should be R1,520.00");
        }

        // <----- UNIT TESTS — PAYE Deduction ----->
        [TestMethod]
        [TestCategory("Unit - PAYE")]
        public void PAYE_NoDependents_40Hours_CorrectAmount()
        {
            // PAYE = (38000 - (38000 × 0.0575 × 0)) × 0.25 = 38000 × 0.25 = R9,500.00
            var calc    = new PayrollCalculator("John Smith", 40, 0);
            double paye = calc.CalculatePAYE(38000.00);
            Assert.AreEqual(9500.00, paye, 0.01,
                "PAYE with 0 dependents on R38,000 should be R9,500.00");
        }

        [TestMethod]
        [TestCategory("Unit - PAYE")]
        public void PAYE_2Dependents_40Hours_ReducedAmount()
        {
            // PAYE = (38000 - (38000 × 0.0575 × 2)) × 0.25
            //      = (38000 - 4370) × 0.25
            //      = 33630 × 0.25 = R8,407.50
            var calc    = new PayrollCalculator("Jane Doe", 40, 2);
            double paye = calc.CalculatePAYE(38000.00);
            Assert.AreEqual(8407.50, paye, 0.01,
                "PAYE with 2 dependents on R38,000 should be R8,407.50");
        }

        [TestMethod]
        [TestCategory("Unit - PAYE")]
        public void PAYE_10Dependents_40Hours_MaxAllowance()
        {
            // PAYE = (38000 - (38000 × 0.0575 × 10)) × 0.25
            //      = (38000 - 21850) × 0.25
            //      = 16150 × 0.25 = R4,037.50
            var calc = new PayrollCalculator("Max Allowance", 40, 10);
            double paye = calc.CalculatePAYE(38000.00);
            Assert.AreEqual(4037.50, paye, 0.01,
                "PAYE with 10 dependents on R38,000 should be R4,037.50");
        }

        // <----- UNIT TESTS — Membership Fee ----->
        [TestMethod]
        [TestCategory("Unit - Membership")]
        public void Membership_GrossPay38000_Returns4940()
        {
            // Membership = 38000 × 0.13 = R4,940.00
            var calc   = new PayrollCalculator("John Smith", 40, 0);
            double fee = calc.CalculateMembershipFee(38000.00);
            Assert.AreEqual(4940.00, fee, 0.01,
                "Membership fee on R38,000 should be R4,940.00");
        }

        [TestMethod]
        [TestCategory("Unit - Membership")]
        public void Membership_GrossPay152000_Returns19760()
        {
            // Membership = 152000 × 0.13 = R19,760.00
            var calc = new PayrollCalculator("Jane Doe", 160, 0);
            double fee = calc.CalculateMembershipFee(152000.00);
            Assert.AreEqual(19760.00, fee, 0.01,
                "Membership fee on R152,000 should be R19,760.00");
        }


        // <----- UNIT TESTS — Net Pay ----->        
        [TestMethod]
        [TestCategory("Unit - NetPay")]
        public void NetPay_40Hours_0Dependents_CorrectAmount()
        {
            // Gross  = R38,000
            // UIF    = R380
            // PAYE   = R9,500
            // Member = R4,940
            // Total  = R14,820
            // Net    = R38,000 - R14,820 = R23,180.00
            var calc = new PayrollCalculator("John Smith", 40, 0);
            calc.CalculateAllDeductions();
            Assert.AreEqual(23180.00, calc.NetPay, 0.01,
                "Net pay for 40 hours, 0 dependents should be R23,180.00");
        }

        [TestMethod]
        [TestCategory("Unit - NetPay")]
        public void NetPay_40Hours_2Dependents_CorrectAmount()
        {
            // Gross  = R38,000
            // UIF    = R380
            // PAYE   = R8,407.50
            // Member = R4,940
            // Total  = R13,727.50
            // Net    = R38,000 - R13,727.50 = R24,272.50
            var calc = new PayrollCalculator("Jane Doe", 40, 2);
            calc.CalculateAllDeductions();
            Assert.AreEqual(24272.50, calc.NetPay, 0.01,
                "Net pay for 40 hours, 2 dependents should be R24,272.50");
        }

        // <----- UNIT TESTS — Input Validation (Exception Testing) ----->
        [TestMethod]
        [TestCategory("Unit - Validation")]
        // [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyName_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            // An empty contractor name must throw ArgumentException
            Assert.ThrowsExactly<ArgumentException>(() => new PayrollCalculator("", 40, 0));
        }

        [TestMethod]
        [TestCategory("Unit - Validation")]
        // [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhitespaceName_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            // Whitespace-only name must be rejected
            Assert.ThrowsExactly<ArgumentException>(() => new PayrollCalculator("   ", 40, 0));
        }

        [TestMethod]
        [TestCategory("Unit - Validation")]
        // [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_NegativeHours_ThrowsArgumentOutOfRangeException()
        {
            // Arrange & Act & Assert
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => new PayrollCalculator("Test User", -5, 0));
        }

        [TestMethod]
        [TestCategory("Unit - Validation")]
        // [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_ZeroHours_ThrowsArgumentOutOfRangeException()
        {
            // Arrange & Act & Assert
            // Zero hours is not a valid working period
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => new PayrollCalculator("Test User", 0, 0));
        }

        [TestMethod]
        [TestCategory("Unit - Validation")]
        // [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_NegativeDependents_ThrowsArgumentOutOfRangeException()
        {
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => new PayrollCalculator("Test User", 40, -1));
        }

        [TestMethod]
        [TestCategory("Unit - Validation")]
        // [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Dependents11_ThrowsArgumentOutOfRangeException()
        {
            // Arrange & Act & Assert
            // 11 dependents exceeds the maximum limit of 10
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => new PayrollCalculator("Test User", 40, 11));
        }

        [TestMethod]
        [TestCategory("Unit - Validation")]
        public void Constructor_ValidInputs_DoesNotThrow()
        {
            // Boundary: exactly 10 dependents must be accepted
            var calc = new PayrollCalculator("Valid User", 40, 10);
            Assert.IsNotNull(calc);
        }

        // <----- 
        // INTEGRATION TESTS — End-to-End Workflow
        // Tests that input flows correctly through calculation to output
        // ----->
        [TestMethod]
        [TestCategory("Integration")]
        public void Integration_HoursFlowsToGrossPayCorrectly()
        {
            // Verify that hours entered by user reach gross pay calculation correctly
            var calc = new PayrollCalculator("Integration User", 80, 0);
            calc.CalculateAllDeductions();
            // 80 hours × R950 = R76,000
            Assert.AreEqual(76000.00, calc.GrossPay, 0.01,
                "Hours entered must be correctly passed to gross pay calculation.");
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void Integration_GrossPayFlowsToAllDeductionsCorrectly()
        {
            // Verify that gross pay feeds correctly into UIF, PAYE, and membership
            var calc = new PayrollCalculator("Integration User", 80, 0);
            calc.CalculateAllDeductions();

            double expectedGross      = 76000.00;
            double expectedUIF        = expectedGross * 0.01;             // R760
            double expectedPAYE       = expectedGross * 0.25;             // R19,000
            double expectedMembership = expectedGross * 0.13;             // R9,880

            Assert.AreEqual(expectedUIF,        calc.UIFDeduction,   0.01, "UIF should be 1% of gross pay.");
            Assert.AreEqual(expectedPAYE,       calc.PAYEDeduction,  0.01, "PAYE should be 25% of gross (0 dependents).");
            Assert.AreEqual(expectedMembership, calc.MembershipFee,  0.01, "Membership should be 13% of gross pay.");
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void Integration_AllDeductionsCombineIntoTotalCorrectly()
        {
            // Verify total deductions is the correct sum of UIF + PAYE + Membership
            var calc = new PayrollCalculator("Integration User", 80, 1);
            calc.CalculateAllDeductions();

            double expectedTotal = calc.UIFDeduction + calc.PAYEDeduction + calc.MembershipFee;
            Assert.AreEqual(expectedTotal, calc.TotalDeductions, 0.01,
                "Total deductions must equal UIF + PAYE + Membership.");
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void Integration_NetPayEqualsGrossMinusTotalDeductions()
        {
            // Verify that net pay is correctly derived as gross minus total deductions
            var calc = new PayrollCalculator("Integration User", 80, 2);
            calc.CalculateAllDeductions();

            double expectedNet = calc.GrossPay - calc.TotalDeductions;
            Assert.AreEqual(expectedNet, calc.NetPay, 0.01,
                "Net pay must equal Gross Pay minus Total Deductions.");
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void Integration_DependentAllowanceReducesPAYE()
        {
            // Verify increasing dependents reduces PAYE (tax relief functionality)
            var calc0Dep = new PayrollCalculator("No Dependents", 40, 0);
            var calc3Dep = new PayrollCalculator("3 Dependents",  40, 3);

            calc0Dep.CalculateAllDeductions();
            calc3Dep.CalculateAllDeductions();

            Assert.IsLessThan(calc0Dep.PAYEDeduction, calc3Dep.PAYEDeduction,
                "More dependents must result in a lower PAYE deduction.");
        }
    }
}
