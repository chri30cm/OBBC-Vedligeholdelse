using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace UnitTestProject1
{
    [TestClass]
    public class GodsAnswer
    {
        DatabaseController database = new DatabaseController();
        ReportFactory reportFactory = new ReportFactory();

        [TestMethod]
        public void IsListWorking()
        {
            database.ReadOnlyAllErrorReports();

            Assert.AreEqual(2, reportFactory.GetErrorReports().Count);
        }

        [TestMethod]
        public void IsListWorking2()
        {
            database.ReadAndShowErrorReports();

            Assert.AreEqual(2, reportFactory.GetErrorReports().Count);
        }
    }
}
