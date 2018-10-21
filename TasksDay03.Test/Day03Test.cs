using System;
using System.Security.AccessControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static TasksDay03.Day03;

namespace TasksDay03.Test
{
    [TestClass]
    public class Day03Test
    {
        public TestContext TestContext { get; set; }
        
        [DataSource("System.Data.OleDb",
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\TestDataSource.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES\";",
            "Shit1$",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void FindNthRoot_DDT()
        {
            double a = Convert.ToDouble(TestContext.DataRow["a"]);
            int n = Convert.ToInt32(TestContext.DataRow["n"]);
            double precision = Convert.ToDouble(TestContext.DataRow["precision"]);
            double expectedResult = Convert.ToDouble(TestContext.DataRow["expectedResult"]);

            double actual = FindNthRoot(a, n, precision);

            Assert.AreEqual(expectedResult, actual);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRoot_NegativeNumberWithEvenRoot_ThrowArgumentException()
            => FindNthRoot(-0.01, 2, 0.0001);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRoot_NegativeRoot_ThrowArgumentException()
            => FindNthRoot(0.01, -2, 0.0001);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRoot_NegativePrecision_ThrowArgumentException()
            => FindNthRoot(0.01, 2, -0.0001);
    }
}
