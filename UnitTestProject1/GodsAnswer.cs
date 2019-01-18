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
            ErrorReport report1 = new ErrorReport(1, "a", "b", "c", "d");
            ErrorReport report2 = new ErrorReport(2, "e", "f", "g", "h", "i");
            reportFactory.AddReport(report1);
            reportFactory.AddReport(report2);

            Assert.AreEqual(2, reportFactory.GetErrorReports().Count);
        }

        [TestMethod]
        public void IsListWorking2()
        {
            database.ReadAndShowErrorReports();

            Assert.AreEqual(20, reportFactory.GetErrorReports().Count);
        }
    }
}
