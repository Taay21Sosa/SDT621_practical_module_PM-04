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
    }
}
