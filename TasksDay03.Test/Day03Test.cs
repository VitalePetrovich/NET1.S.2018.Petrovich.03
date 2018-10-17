using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static TasksDay03.Day03;

namespace TasksDay03.Test
{
    [TestClass]
    public class Day03Test
    {
        [TestMethod]
        public void FindNthRoot_3thRootFrom8_2Returned()
        {
            double a = 8;
            int n = 3;
            double precision = 0.0001;
            double expected = 2;

            double actual = FindNthRoot(a, n, precision);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNthRoot_3thRootFromMinus0p008_Minus0p2Returned()
        {
            double a = -0.008;
            int n = 3;
            double precision = 0.1;
            double expected = -0.2;

            double actual = FindNthRoot(a, n, precision);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void FindNthRoot_9thRootFrom0p004241979_0p545Returned()
        {
            double a = 0.004241979;
            int n = 9;
            double precision = 0.00000001;
            double expected = 0.545;

            double actual = FindNthRoot(a, n, precision);

            Assert.AreEqual(expected, actual);
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
