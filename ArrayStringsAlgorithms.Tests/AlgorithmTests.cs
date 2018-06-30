using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace ArraysStringsAlgorithms.Tests
{
    [TestClass]
    public class AlgorithmTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_ILessThanJ_Exception() => Algorithms.InsertNumber(15,15,8,3);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_IOrJIsOutOfRange_Exception() => Algorithms.InsertNumber(15, 15, 33, -5);

        [TestMethod]
        public void InsertNumber_NullPositionsEqualNumbers_InsertToNullPosOneBit()
        {
            Assert.AreEqual((Algorithms.InsertNumber(15, 15, 0, 0)), 15);
        }

        [TestMethod]
        public void InsertNumber_NullPositionsDifferentNumbers_InsertToNullPosOneBit()
        {
            Assert.AreEqual((Algorithms.InsertNumber(8, 15, 0, 0)), 9);
        }

        [TestMethod]
        public void InsertNumber_NonEqualPositionsDifferentNumbers_InsertToNotNullPosEqualPos()
        {
            Assert.AreEqual((Algorithms.InsertNumber(8, 15, 3, 3)), 8);
        }

        [TestMethod]
        public void InsertNumber_NonEqualPositionsDifferentNumbers_InsertToNotNullPosDifferentPos()
        {
            Assert.AreEqual((Algorithms.InsertNumber(8, 15, 3, 8)), 120);
        }

        [TestMethod]
        public void FilterDigit_RandomArrayWithDigit_ArrayOnlyWithDigit()
        {
            int[] expected = { 7, 7, 70, 17 };
            CollectionAssert.AreEqual(expected, Algorithms.FilterDigit(7, 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17));
        }

        [TestMethod]
        public void FilterDigit_RandomArrayWoutDigit_EmptyArray()
        {       
            int[] expected = { };
            CollectionAssert.AreEqual(expected, Algorithms.FilterDigit(7, 1, 2, 3, 4, 5, 6, 68, 69, 15));
        }

        [TestMethod]
        public void FilterDigit_ArrayOnlyWithDigit_UnchangedArray()
        {
            int[] expected = { 7, 7, 70, 17 };
            CollectionAssert.AreEqual(expected, Algorithms.FilterDigit(7, 7, 7, 70, 17));
        }

    }
}
