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
            var calc    = new PayrollCalculator("Max Allowance", 40, 10);
            double paye = calc.CalculatePAYE(38000.00);
            Assert.AreEqual(4037.50, paye, 0.01,
                "PAYE with 10 dependents on R38,000 should be R4,037.50");
        }
    }
}
