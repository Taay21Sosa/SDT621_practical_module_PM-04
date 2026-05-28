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
            
            TestContext.WriteLine($"[TEARDOWN] Finished test '{TestContext.TestName}' with status: {testStatus}");
            TestContext.WriteLine("--------------------------------------------------");
        }
    }
}
